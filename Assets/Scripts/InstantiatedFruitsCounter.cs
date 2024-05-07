using UnityEngine;

public class InstantiatedFruitsCounter 
{
    private int _fruitsCounter;
    public int FruitsCounter => _fruitsCounter;

    public void AddToCounter(Fruit fruit)
    {
        _fruitsCounter++;

        fruit.OnFruitDestroyed += RemoveFromCounter;
    }

    private void RemoveFromCounter(Fruit fruit)
    {
        fruit.OnFruitDestroyed -= RemoveFromCounter;
        _fruitsCounter--;
    }
}
