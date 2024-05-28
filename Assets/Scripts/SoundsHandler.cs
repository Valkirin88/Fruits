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
        _source.clip = _newFruitClip;
        _source.Play();
    }

    private void PlayMerge()
    {
        _source.clip = _mergeClip;
        _source.Play();
    }

    private void HasBomb(Fruit fruit)
    {

        if (fruit.gameObject.GetComponent<Bomb>())
        {
            Debug.Log("bomb");
            _source.clip = _bombClip;
            _source.Play();
        }
    }

    private void OnDestroy()
    {
        _fruitInstantiator.OnFruitInstantiatedAtTop -= PlayNewFruit;
        _collisionHandler.OnCollisionDone -= PlayMerge;
    }
}
