using System;
using System.Collections.Generic;
using UnityEngine;

public class FruitCountDown
{
    public event Action OnCountFinished;
    public event Action<bool> OnDanger;

    private List<Fruit> _fruitsInsideGameOverZone;

    public FruitCountDown()
    {
        _fruitsInsideGameOverZone = new List<Fruit>();
    }

    public void AddFruit(Fruit fruit)
    {
        if (!_fruitsInsideGameOverZone.Contains(fruit))
        {
            _fruitsInsideGameOverZone.Add(fruit);
        }
    }
    public void RemoveFruit(Fruit fruit)
    {
        if (_fruitsInsideGameOverZone.Contains(fruit))
        {
            fruit.LifeTime = 3;
            _fruitsInsideGameOverZone.Remove(fruit);
        }
    }

    public void Update()
    {
        for (var i= _fruitsInsideGameOverZone.Count - 1; i >= 0; i--)
        {
            Fruit fruit = _fruitsInsideGameOverZone[i];
            fruit.LifeTime = fruit.LifeTime - Time.deltaTime;
            if (fruit.LifeTime < 0)
            {
                RemoveFruit(fruit);
                OnCountFinished?.Invoke();
            }
        }
        if (_fruitsInsideGameOverZone.Count > 0)
        {
            OnDanger?.Invoke(true);
        }
        else
        {
            OnDanger?.Invoke(false);
        }
    }
}
