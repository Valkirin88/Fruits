using UnityEngine;

public class SpecialEffectsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _bombEffect;
    [SerializeField]
    private GameObject _collisionObject;

    private ParticleSystem _collisionEffect;

    private void Start()
    {
        _collisionEffect = _collisionObject.GetComponent<ParticleSystem>();
    }

    public void ShowCollision(Vector3 position)
    {
        Debug.Log("Effect");
        _collisionEffect.transform.position = position;
        _collisionEffect.Play();
    }
}
