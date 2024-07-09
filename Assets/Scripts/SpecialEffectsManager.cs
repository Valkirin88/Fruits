using UnityEngine;

public class SpecialEffectsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _bombEffect;
    [SerializeField]
    private GameObject _collisionObject;
    [SerializeField]
    private ParticleSystem _collisionEffect;
    [SerializeField]
    private ParticleSystem[] _fireworkEffects;

    private ScoreHandler _scoreHandler;

    public void Initialize(ScoreHandler scoreHandler)
    {
        _collisionEffect = _collisionObject.GetComponent<ParticleSystem>();
        _scoreHandler = scoreHandler;
        _scoreHandler.OnNewThousandScore += ShowFirework;
    }

    private void ShowFirework()
    {
        Debug.Log("fireworks");
        for (int i = 0; i < _fireworkEffects.Length-1; i++)
        _fireworkEffects[i].Play();
    }

    public void ShowCollision(Vector3 position)
    {
        _collisionEffect.transform.position = position;
        _collisionEffect.Play();
    }

    private void OnDestroy()
    {
        _scoreHandler.OnNewThousandScore -= ShowFirework;
    }
}
