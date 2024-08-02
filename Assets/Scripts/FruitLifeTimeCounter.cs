using System.Collections.Generic;
using UnityEngine;

public class FruitLifeTimeCounter 
{
    private List<Fruit> _fruits;
    private FruitsContainer _fruitsContainer;

    public FruitLifeTimeCounter(FruitsContainer fruitsContainer)
    {
        _fruits = new List<Fruit>();
        _fruitsContainer = fruitsContainer;
        _fruits = _fruitsContainer.Fruits;
    }

    public void Update()
    {
        foreach (var fruit in _fruits) 
        {
            fruit.LifeTime = fruit.LifeTime + Time.deltaTime;
        }
    }
}
