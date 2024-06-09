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
    [SerializeField]
    private AudioClip _collided;


    private FruitsInstantiator _fruitInstantiator;
    private CollisionHandler _collisionHandler;
   
    public void Initialize(FruitsInstantiator fruitsInstantiator, CollisionHandler collisionHandler)
    {
        _fruitInstantiator = fruitsInstantiator;
        _collisionHandler = collisionHandler;
        _fruitInstantiator.OnFruitInstantiatedAtTop += PlayNewFruit;
        _fruitInstantiator.OnFruitInstantiated += HasBomb;
        _collisionHandler.OnCollisionDone += PlayMerge;
        _collisionHandler.OnFruictsCollided += PlayCollided;
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
            Invoke("PlayBomb", 3f);
        }
    }

    private void PlayBomb() 
    {
        _source.PlayOneShot(_bombClip);
    }

    private void PlayCollided()
    {
        _source.PlayOneShot(_collided);
    }

    private void OnDestroy()
    {
        _fruitInstantiator.OnFruitInstantiatedAtTop -= PlayNewFruit;
        _collisionHandler.OnCollisionDone -= PlayMerge;
        _collisionHandler.OnFruictsCollided -= PlayCollided;
    }
}
