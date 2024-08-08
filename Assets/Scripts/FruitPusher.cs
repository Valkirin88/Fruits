using UnityEngine;

public class FruitPusher 
{
    private FruitsInstantiator _fruitInstantiator;
    private Lemur _lemur;
    private Fruit _fruit;
    public FruitPusher(FruitsInstantiator fruitsInstantiator, Lemur lemur)
    {
        _fruitInstantiator = fruitsInstantiator;
        _fruitInstantiator.OnFruitInstantiated += HandleNewFruit;
        _lemur = lemur;
        _lemur.OnLemurAtLowPosition += PushFruit;
        
    }
    private void HandleNewFruit(Fruit fruit)
    {
        _fruit = fruit;
    }
    private void PushFruit()
    {
        var rigidbody = _fruit.gameObject.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector3(0, -10, 0);
    }
}
