using UnityEngine;

public class InstantiatedFruitsCounter 
{
    private int _fruitsCounter;
    public int FruitsCounter => _fruitsCounter;

    public void AddToCounter(GameObject gameObject)
    {
        _fruitsCounter++;
        IFruit fruit = gameObject.GetComponent<IFruit>();
        fruit.OnFruitDestroy += RemoveFromCounter;
    }

    private void RemoveFromCounter(GameObject gameObject)
    {
        IFruit fruit = gameObject.GetComponent<IFruit>();
        fruit.OnFruitDestroy -= RemoveFromCounter;
        _fruitsCounter--;
    }
}
