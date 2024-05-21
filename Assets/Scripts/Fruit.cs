using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public event Action<Fruit, Fruit, Vector3> OnFruitCollided;
    public event Action<Fruit> OnFruitDestroyed;

    public bool IsCollided;
    public FruitsConfig FruitsConfig { get; private set; }
    public float LifetimeDuration { get; private set;}


    public void Construct(FruitsConfig fruitsConfig)
    {
        FruitsConfig = fruitsConfig;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if ( col.gameObject.TryGetComponent<Fruit>(out var fruit) && LifetimeDuration > fruit.LifetimeDuration)
        {
            IsCollided = true;
            var contact = col.contacts[0].point;
            var collidedPosition = new Vector3(contact.x, contact.y, 0);
            OnFruitCollided.Invoke(this, fruit, collidedPosition);
        }
    }

    private void Update()
    {
        LifetimeDuration = Time.deltaTime + LifetimeDuration;
    }

    private void OnDestroy()
    {
        var fruit = gameObject.GetComponent<Fruit>();   
        OnFruitDestroyed?.Invoke(fruit);
    }
}
