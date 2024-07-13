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

    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private Transform _scoreWindow;

    private ScoreHandler _scoreHandler;
    private Vector3 _scoreWindowPosition;

    public void Initialize(ScoreHandler scoreHandler)
    {
        _collisionEffect = _collisionObject.GetComponent<ParticleSystem>();
        _scoreHandler = scoreHandler;
        _scoreHandler.OnNewThousandScore += ShowFirework;

        _scoreWindowPosition = Camera.main.ScreenToWorldPoint(_scoreWindow.position + new Vector3(0, -10, 10));
    }

    private void ShowFirework()
    {
        Debug.Log("fireworks");
        for (int i = 0; i < _fireworkEffects.Length - 1; i++)
        {
            _fireworkEffects[i].transform.position = _scoreWindowPosition;
            _fireworkEffects[i].Play();
        }
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
