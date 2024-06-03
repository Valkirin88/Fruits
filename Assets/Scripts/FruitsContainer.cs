using System;
using System.Collections.Generic;

public class FruitsContainer 
{
    public event Action OnFuitsNumberChanged;

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
        fruit.OnFruitDestroyed += RemoveFruit;
        OnFuitsNumberChanged?.Invoke();
    }

    private void RemoveFruit(Fruit fruit)
    {
        Fruits.Remove(fruit);
        fruit.OnFruitDestroyed -= RemoveFruit;
        OnFuitsNumberChanged?.Invoke();
    }

    public void Destroy()
    {
        //_fruitsInstantiator.OnFruitInstantiated -= AddFruit;
    }
}
