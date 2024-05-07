using System.Collections.Generic;
using UnityEngine;

public class FruitsContainer 
{
    private List<Fruit> _fruits;
    private Fruit _fruit;
    private FruitsInstantiator _fruitsInstantiator;

    public List<Fruit> Fruits  => _fruits; 

    public FruitsContainer(FruitsInstantiator fruitsInstantiator)
    {
        _fruits = new List<Fruit>();
        _fruitsInstantiator = fruitsInstantiator;
        _fruitsInstantiator.OnFruitInstantiated += AddFruit;
    }

    public void AddFruit(Fruit fruit)
    {
        Fruits.Add(fruit);
        _fruit.OnFruitDestroyed += RemoveFruit;
    }

    private void RemoveFruit(Fruit fruit)
    {
        Fruits.Remove(fruit);
    }
}
