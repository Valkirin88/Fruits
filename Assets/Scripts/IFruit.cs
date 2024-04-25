using UnityEngine;

interface IFruit 
{
    void OnCollisionEnter2D(Collision2D col);

    void LifeDurationTimer();
}
