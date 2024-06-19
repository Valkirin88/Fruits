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
    private Bomb _bomb;
   
    public void Initialize(FruitsInstantiator fruitsInstantiator, CollisionHandler collisionHandler)
    {
        _fruitInstantiator = fruitsInstantiator;
        _collisionHandler = collisionHandler;
        _fruitInstantiator.OnFruitInstantiatedAtTop += PlayNewFruit;
        _fruitInstantiator.OnBombInstantiated += SubscribeOnBomb;
        _collisionHandler.OnCollisionDone += PlayMerge;
        if (!GameInfo.IsSoundOn)
            _source.mute = true;
    }

    private void PlayNewFruit()
    {
        _source.PlayOneShot(_newFruitClip);
    }

    private void PlayMerge()
    {
        _source.PlayOneShot(_mergeClip);
    }

    private void SubscribeOnBomb(Bomb bomb)
    {
        _bomb = bomb;
        _bomb.OnBombExploded += PlayBomb;
    }

    private void PlayBomb() 
    {
        UnsubscribeBomb();
        _source.PlayOneShot(_bombClip);
    }

    private void UnsubscribeBomb()
    {
        _bomb.OnBombExploded -= PlayBomb;
    }

    private void PlayCollided()
    {
        _source.PlayOneShot(_collided);
    }

    private void OnDestroy()
    {
        _fruitInstantiator.OnFruitInstantiatedAtTop -= PlayNewFruit;
        _fruitInstantiator.OnBombInstantiated -= SubscribeOnBomb;
        _collisionHandler.OnCollisionDone -= PlayMerge;
    }
}
