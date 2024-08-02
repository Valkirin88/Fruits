using UnityEngine;

public class FruitPusher 
{
    private FruitsInstantiator _fruitInstantiator;

    public FruitPusher(FruitsInstantiator fruitsInstantiator)
    {
        _fruitInstantiator = fruitsInstantiator;
        _fruitInstantiator.OnFruitInstantiated += PushFruit;
    }

    private void PushFruit(Fruit fruit)
    {
        //var rigidbody = fruit.gameObject.GetComponent<Rigidbody2D>();
        //rigidbody.velocity = new Vector3(0, -5, 0);
    }
}
