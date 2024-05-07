using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter 
{
    private int _score;
    private List<Fruit> fruits;
    private Fruit _fruit;
    private FruitsInstantiator _fruitsInstantiator;

    public ScoreCounter(FruitsInstantiator fruitsInstantiator)
    {
        fruits = new List<Fruit>();
        _fruitsInstantiator = fruitsInstantiator;
        _fruitsInstantiator.OnFruitInstantiated += AddFruit;
    }

    public void AddFruit(Fruit fruit)
    {
        fruits.Add(fruit);
        fruit.OnFruitDestroyed += RemoveFruitFromCounter;
    }

    private void RemoveFruitFromCounter(Fruit fruit)
    {
        _score++;
        fruits.Remove(fruit);
        Debug.Log(_score);
    }
}
