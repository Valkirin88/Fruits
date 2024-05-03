using System;
using UnityEngine;

public class Tomato : MonoBehaviour, IFruit
{
    [HideInInspector]
    public float LifeDuration;
    [HideInInspector]
    private Action<GameObject> _onFruitDestroy;

    [SerializeField]
    private GameObject _orangePrefab;

    private GameObject _orange;

    Action<GameObject> IFruit.OnFruitDestroy
    { get { return _onFruitDestroy; } set{ _onFruitDestroy = value; }}

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Tomato>() != null)
        {
            if (LifeDuration > col.gameObject.GetComponent<Tomato>().LifeDuration)
            {       
                _orange = Instantiate(_orangePrefab, col.transform.position, Quaternion.identity);
                _orange.transform.SetParent(null);
            }
            IFruit fruit = this;
            fruit.DestroyFruit(col.gameObject);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LostZone>())
            Debug.Log("You loose");
    }

    private void Update()
    {
        LifeDurationTimer();
    }
    public void LifeDurationTimer()
    {
        LifeDuration += Time.deltaTime;
    }
}
