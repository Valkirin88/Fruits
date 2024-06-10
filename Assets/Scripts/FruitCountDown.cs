using System;
using System.Collections.Generic;
using UnityEngine;

public class FruitCountDown
{
    public event Action OnCountFinished;
    public event Action<bool> OnDanger;

    private List<Fruit> _fruitsInsideGameOverZone;
    private FruitsInstantiator _fruitsInstantiator;

    private float _timerAfterBomb = 7f;
    public FruitCountDown(FruitsInstantiator fruitsInstantiator)
    {
        _fruitsInstantiator = fruitsInstantiator;
        _fruitsInstantiator.OnBombInstantiated += StartBombTimer;
        _fruitsInsideGameOverZone = new List<Fruit>();
    }

    private void StartBombTimer()
    {
        _timerAfterBomb = 7f;
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
        Debug.Log(GetTimerAfterBomb());
        if (GetTimerAfterBomb() <= 0)
        {
            for (var i = _fruitsInsideGameOverZone.Count - 1; i >= 0; i--)
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

    private float GetTimerAfterBomb()
    {
        _timerAfterBomb = _timerAfterBomb - Time.deltaTime;
        if (_timerAfterBomb < 0)
            return 0f;
        else
        return _timerAfterBomb;
    }
}
