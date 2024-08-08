using UnityEngine;

public class FruitPusher 
{
    private FruitsInstantiator _fruitInstantiator;
    private Lemur _lemur;
    private Fruit _fruit;

    public FruitPusher(FruitsInstantiator fruitsInstantiator, Lemur lemur)
    {
        _fruitInstantiator = fruitsInstantiator;
        _fruitInstantiator.OnFruitInstantiated += HandleFruit;
        _lemur = lemur;
        _lemur.OnLemurAtLowPosition += PushFruit;
    }

    private void HandleFruit(Fruit fruit)
    {
        _fruit = fruit;
    }

    private void PushFruit()
    {
        var rigidbody = _fruit.gameObject.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector3(0, -10, 0);
    }
}
