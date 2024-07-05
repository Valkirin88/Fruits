using System;
using System.Collections.Generic;
using UnityEngine;

public class FruitCountDown
{
    public event Action OnCountFinished;
    public event Action<bool> OnDanger;

    private List<Fruit> _fruitsInsideGameOverZone;
    private FruitsInstantiator _fruitsInstantiator;
    private Bomb _bomb;

    private float _timerAfterBomb = 7f;
    public FruitCountDown(FruitsInstantiator fruitsInstantiator)
    {
        _fruitsInstantiator = fruitsInstantiator;
        _fruitsInstantiator.OnBombInstantiated += SubscribeExplosion;
        _fruitsInsideGameOverZone = new List<Fruit>();
    }

    private void SubscribeExplosion(Bomb bomb)
    {
        _bomb = bomb;
        bomb.OnBombExploded += StartBombTimer;
    }

    private void StartBombTimer()
    {
        _timerAfterBomb = 7f;
        UnsubscribeBomb();
    }

    private void UnsubscribeBomb()
    {
        _bomb.OnBombExploded -= StartBombTimer;
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
            fruit.TillDeathTime = GameInfo.TillDeathTime;
            _fruitsInsideGameOverZone.Remove(fruit);
        }
    }

    public void Update()
    {
        if (GetTimerAfterBomb() <= 0)
        {
            for (var i = _fruitsInsideGameOverZone.Count - 1; i >= 0; i--)
            {
                Fruit fruit = _fruitsInsideGameOverZone[i];
                fruit.TillDeathTime = fruit.TillDeathTime - Time.deltaTime;
                if (fruit.TillDeathTime < 0)
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

    public void Destroy()
    {
        _fruitsInstantiator.OnBombInstantiated -= SubscribeExplosion;
    }
}
