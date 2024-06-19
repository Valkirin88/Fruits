using CandyCoded.HapticFeedback;
using UnityEngine;

public class VibrationHandler : MonoBehaviour
{
    private CollisionHandler _collisionHandler;
    private FruitsInstantiator _fruitsInstantiator;
    private Bomb _bomb;

    public void Initialize(CollisionHandler collisionHandler, FruitsInstantiator fruitsInstantiator)
    {
        _collisionHandler = collisionHandler;
        _fruitsInstantiator = fruitsInstantiator;
        _collisionHandler.OnCollisionDone += DoShortVibro;
        _fruitsInstantiator.OnBombInstantiated += SubscribeBomb;
}

    private void DoShortVibro()
    {
        HapticFeedback.LightFeedback();
    }
    private void SubscribeBomb(Bomb bomb)
    {
        _bomb = bomb;
        _bomb.OnBombExploded += DoLongVibro;
    }

    private void DoLongVibro()
    {
        UnsubscribeBomb();
        Handheld.Vibrate();
    }

    private void UnsubscribeBomb()
    {
        _bomb.OnBombExploded -= DoLongVibro;
    }

    private void OnDestroy()
    {
        _collisionHandler.OnCollisionDone -= DoShortVibro;
        _fruitsInstantiator.OnBombInstantiated -= SubscribeBomb;
    }
}
