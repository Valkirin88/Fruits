using System;
using UnityEngine;

public class Strawberry : MonoBehaviour, IFruit
{
    [HideInInspector]
    public float LifeDuration;
    [HideInInspector]
    public Action<GameObject> OnFruitDestroy;

    [SerializeField]
    private GameObject _tomatoPrefab;

    private GameObject _tomato;
    IFruit fruit;

    Action<GameObject> IFruit.OnFruitDestroy { get; set; }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Strawberry>() != null)
        {
            if (LifeDuration > col.gameObject.GetComponent<Strawberry>().LifeDuration)
            { 
                _tomato = Instantiate(_tomatoPrefab, col.transform.position, Quaternion.identity);
                _tomato.transform.SetParent(null);
            }
            fruit = this;
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
