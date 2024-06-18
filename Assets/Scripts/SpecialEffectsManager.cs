using UnityEngine;

public class SpecialEffectsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _bombEffect;
    [SerializeField]
    private GameObject _collisionObject;
    [SerializeField]
    private ParticleSystem _collisionEffect;

    private void Start()
    {
        _collisionEffect = _collisionObject.GetComponent<ParticleSystem>();
    }

    public void ShowCollision(Vector3 position)
    {
        _collisionEffect.transform.position = position;
        _collisionEffect.Play();
    }
}
