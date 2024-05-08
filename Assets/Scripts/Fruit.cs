using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private float _lifeDuration;

    public float LifeDuration => _lifeDuration; 

    public event Action<GameObject, GameObject, Vector3> OnFruitCollided;
    public event Action<Fruit> OnFruitDestroyed;

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Fruit>() != null)
        {
            var fruit = col.gameObject.GetComponent<Fruit>();
            OnFruitCollided.Invoke(this.gameObject, col.gameObject, col.transform.position);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LostZone>())
            Debug.Log("You loose");
    }

    private void Update()
    {
        _lifeDuration = _lifeDuration + Time.deltaTime;
    }

    private void OnDestroy()
    {
        var fruit = gameObject.GetComponent<Fruit>();   
        OnFruitDestroyed?.Invoke(fruit);
    }
}
