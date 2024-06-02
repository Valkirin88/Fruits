using System;
using System.Collections.Generic;
using UnityEngine;

public class FruitCountDown
{
    public event Action OnCountFinished;
    public event Action<bool> OnDanger;
    public event Action<List<Fruit>> OnFruitsInDanger;

    private List<Fruit> _fruits;

    public FruitCountDown()
    {
        _fruits = new List<Fruit>();
    }

    public void AddFruit(Fruit fruit)
    {
        if (!_fruits.Contains(fruit))
        {
            _fruits.Add(fruit);
            OnFruitsInDanger.Invoke(_fruits);
        }
    }
    public void RemoveFruit(Fruit fruit)
    {
        if (_fruits.Contains(fruit))
        {
            fruit.LifeTime = 3;
            _fruits.Remove(fruit);
            OnFruitsInDanger.Invoke(_fruits);
        }
    }

    public void Update()
    {
        foreach (var fruit in _fruits)
        {
            fruit.LifeTime = fruit.LifeTime - Time.deltaTime;
            if (fruit.LifeTime < 0)
                OnCountFinished?.Invoke();
        }
        if (_fruits.Count > 0)
        {
            OnDanger?.Invoke(true);
        }
        else
        {
            OnDanger?.Invoke(false);
        }
    }
}
