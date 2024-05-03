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
    private void Update()
    {
        LifeDurationTimer();
    }
    public void LifeDurationTimer()
    {
        LifeDuration += Time.deltaTime;
    }

}
