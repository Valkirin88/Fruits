using System.Collections.Generic;
using UnityEngine;

public class SmilesHandler 
{
    private FruitsContainer _fruitsContainer;
    private List<Fruit> _fruits;

    private float _tillSleepTime = 20f;

    public SmilesHandler(FruitsContainer fruitsContainer)
    {
        _fruitsContainer = fruitsContainer;
        _fruits = _fruitsContainer.Fruits;
    }

    public void Update()
    {
        foreach(var fruit in _fruits)
        {
            if(fruit.IsInDanger)
            {
                fruit.InDangerSmile.SetActive(true);
                fruit.FlyingSmile.SetActive(false);
                fruit.LayingSmileSmile.SetActive(false);
                fruit.SleepySmile.SetActive(false);
            }
            if (!fruit.IsInDanger && fruit.IsFirstCollided)
            {
                fruit.InDangerSmile.SetActive(false);
                fruit.FlyingSmile.SetActive(false);
                fruit.LayingSmileSmile.SetActive(true);
                fruit.SleepySmile.SetActive(false);
            }
            if (fruit.LifeTime > _tillSleepTime) 
            {
                fruit.InDangerSmile.SetActive(false);
                fruit.FlyingSmile.SetActive(false);
                fruit.LayingSmileSmile.SetActive(false);
                fruit.SleepySmile.SetActive(true);
            }
        }
    }
}
