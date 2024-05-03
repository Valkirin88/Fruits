using System;
using UnityEngine;

interface IFruit 
{
    Action<GameObject> OnFruitDestroy { get; set; }
    void OnCollisionEnter2D(Collision2D col);

    void LifeDurationTimer();

    void DestroyFruit(GameObject fruit)
    {
        OnFruitDestroy?.Invoke(fruit);
        UnityEngine.Object.Destroy(fruit);
        UnityEngine.Object.Destroy((UnityEngine.Object)this);
    }
}
