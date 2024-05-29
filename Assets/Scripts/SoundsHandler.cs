using System;
using UnityEngine;

public class SoundsHandler : MonoBehaviour
{
    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioClip _mergeClip;
    [SerializeField]
    private AudioClip _newFruitClip;
    [SerializeField]
    private AudioClip _bombClip;

    private FruitsInstantiator _fruitInstantiator;
    private CollisionHandler _collisionHandler;
   
    public void Initialize(FruitsInstantiator fruitsInstantiator, CollisionHandler collisionHandler)
    {
        _fruitInstantiator = fruitsInstantiator;
        _collisionHandler = collisionHandler;
        _fruitInstantiator.OnFruitInstantiatedAtTop += PlayNewFruit;
        _fruitInstantiator.OnFruitInstantiated += HasBomb;
        _collisionHandler.OnCollisionDone += PlayMerge;
    }

    private void PlayNewFruit()
    {
        _source.PlayOneShot(_newFruitClip);
    }

    private void PlayMerge()
    {
        _source.PlayOneShot(_mergeClip);
    }

    private void HasBomb(Fruit fruit)
    {

        if (fruit.gameObject.GetComponent<Bomb>())
        {
            Invoke("PlayBomb", 2f);
        }
    }

    private void PlayBomb() 
    {
        _source.PlayOneShot(_bombClip);
    }

    private void OnDestroy()
    {
        _fruitInstantiator.OnFruitInstantiatedAtTop -= PlayNewFruit;
        _collisionHandler.OnCollisionDone -= PlayMerge;
    }
}
