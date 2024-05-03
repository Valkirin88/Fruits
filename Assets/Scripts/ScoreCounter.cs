using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter 
{
    private int _score;
    private List<IFruit> fruits;
    private IFruit _fruit;
    private FruitsInstantiator _fruitsInstantiator;

    public ScoreCounter(FruitsInstantiator fruitsInstantiator)
    {
        fruits = new List<IFruit>();
        _fruitsInstantiator = fruitsInstantiator;
        _fruitsInstantiator.OnFruitInstantiated += AddFruit;
    }

    public void AddFruit(GameObject gameObject)
    {
        _fruit = gameObject.GetComponent<IFruit>();
        fruits.Add(_fruit);
        _fruit.OnFruitDestroy += RemoveFruitFromCounter;
    }

    private void RemoveFruitFromCounter(GameObject gameObject)
    {
        IFruit fruit = gameObject.GetComponent<IFruit>();
        
        _score++;
        fruits.Remove(fruit);
        Debug.Log(_score);
    }
}
