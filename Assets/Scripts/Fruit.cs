using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public event Action<Fruit, Fruit, Vector3> OnFruitCollided;
    public event Action<Fruit> OnFruitDestroyed;

    public bool IsCollided;
    public FruitsConfig FruitsConfig { get; private set; }
    public float LifetimeDuration { get; private set;}
    public int FruitNumber {  get; private set; } 


    public void Construct(FruitsConfig fruitsConfig, int fruitNumber)
    {
        FruitsConfig = fruitsConfig;
        FruitNumber = fruitNumber;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent<Fruit>(out var fruit) && !IsCollided)
        {
            var contact = col.contacts[0].point;
            var collidedPosition = new Vector3(contact.x, contact.y, 0);
            OnFruitCollided.Invoke(this, fruit, collidedPosition);
        }
    }

    private void OnDestroy()
    {
        var fruit = gameObject.GetComponent<Fruit>();   
        OnFruitDestroyed?.Invoke(fruit);
    }
}
