using System.Collections.Generic;
using UnityEngine;

public class FruitsContainer : MonoBehaviour
{

    public int InstantiatedFruitsCounter;

    private int _count;
    private List<IFruit> fruits = new List<IFruit>();
    private IFruit _fruit;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        _fruit = collision.gameObject.GetComponent<IFruit>();
        if (!fruits.Contains(_fruit))

        AddFruitCounter();
    }

    public void AddFruitCounter()
    {
        fruits.Add(_fruit);
        _count++;
        _fruit.OnFruitDestroy += RemoveFruitFromCounter;
    }

    private void RemoveFruitFromCounter(GameObject gameObject) 
    {
        IFruit fruit = gameObject.GetComponent<IFruit>();
        if (fruits.Contains(_fruit))
        {
            fruits.Remove(_fruit);
            _count--;
        }
    }
    private void Update()
    {
        Debug.Log(_count);
    }
}
