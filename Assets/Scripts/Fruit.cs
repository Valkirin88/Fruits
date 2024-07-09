using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public event Action<Fruit, Fruit, Vector3> OnFruitCollided;
    public event Action<Fruit> OnFruitDestroyed;

    //Smiles
    public GameObject FlyingSmile; 
    public GameObject LayingSmileSmile; 
    public GameObject InDangerSmile;
    public GameObject SleepySmile;

    [HideInInspector]
    public bool IsCollided;
    [HideInInspector]
    public bool IsFirstCollided;
    [HideInInspector]
    public bool IsInMainZone;
    [HideInInspector]
    public bool IsInGameOverZone;
    [HideInInspector]
    public bool IsBlinking;
    [HideInInspector]
    public bool IsInDanger;
    [HideInInspector]
    public bool IsSleep;



    public float TillDeathTime;
    [HideInInspector]
    public float LifeTime;


    public SpriteRenderer SpriteRenderer;

    public FruitsConfig FruitsConfig { get; private set; }
    public int FruitNumber {  get; private set; }

    private void Start()
    {
        TillDeathTime = GameInfo.TillDeathTime;
    }

    public void Construct(FruitsConfig fruitsConfig, int fruitNumber)
    {
        FruitsConfig = fruitsConfig;
        FruitNumber = fruitNumber;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent<Fruit>(out var fruit) && !IsCollided)
        {
            IsFirstCollided = true;
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
