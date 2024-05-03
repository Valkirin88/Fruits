using System;
using UnityEngine;

public class Orange : MonoBehaviour, IFruit
{
    [HideInInspector]
    public float LifeDuration;

    public Action<GameObject> OnFruitDestroy { get; set; }

    public void OnCollisionEnter2D(Collision2D col)
    {
        
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LostZone>())
            Debug.Log("You loose");

    }
    private void Update()
    {
        LifeDurationTimer();
    }
    public void LifeDurationTimer()
    {
        LifeDuration += Time.deltaTime;
    }

}
