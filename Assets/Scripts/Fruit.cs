using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public float LifeDuration { get; private set; } 
    public FruitsConfig FruitsConfig { get; private set; }

    public event Action<Fruit, Fruit, Vector3> OnFruitCollided;
    public event Action<Fruit> OnFruitDestroyed;

    public void Construct(FruitsConfig fruitsConfig)
    {
        FruitsConfig = fruitsConfig;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent<Fruit>(out var fruit))
        {

            OnFruitCollided.Invoke(this, fruit, col.transform.position);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LostZone>())
            Debug.Log("You loose");
    }

    private void Update()
    {
        LifeDuration = LifeDuration + Time.deltaTime;
    }

    private void OnDestroy()
    {
        var fruit = gameObject.GetComponent<Fruit>();   
        OnFruitDestroyed?.Invoke(fruit);
    }
}
