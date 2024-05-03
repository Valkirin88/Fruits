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
            IFruit fruit = this;
            fruit.DestroyFruit(col.gameObject);
        }
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
