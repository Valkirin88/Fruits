using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool IsActiv = true;

    public event Action<Fruit, Fruit, Vector3> OnFruitCollided;
    public event Action<Fruit> OnFruitDestroyed;
    public FruitsConfig FruitsConfig { get; private set; }


    public void Construct(FruitsConfig fruitsConfig)
    {
        FruitsConfig = fruitsConfig;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (IsActiv == true && col.gameObject.TryGetComponent<Fruit>(out var fruit))
        {
            fruit.IsActiv = false;
            var contact = col.contacts[0].point;
            var collidedPosition = new Vector3(contact.x, contact.y, 0);
            OnFruitCollided.Invoke(this, fruit, collidedPosition);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LostZone>())
            Debug.Log("You loose");
    }

    private void OnDestroy()
    {
        var fruit = gameObject.GetComponent<Fruit>();   
        OnFruitDestroyed?.Invoke(fruit);
    }
}
