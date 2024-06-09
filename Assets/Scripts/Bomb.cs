using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private GameObject bombEffect;
    [SerializeField]
    private BombFuse _bombFuse;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private float _explosionRadius = 50;
    private float _explosionForceMulti = 1000000;
    private float _timeTillExplosion = 3f;
    private float _timeTillBombDestroyed = 0.5f;
    private Collider2D[] _colliders;


    private void Start()
    {
        Invoke("Explode", _timeTillExplosion);
    }

    private void Explode()
    {
        _colliders = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

        foreach(Collider2D obj in _colliders)
        {
            Rigidbody2D object_rigidbody = obj.GetComponent<Rigidbody2D>();
            if(object_rigidbody != null)
            {
                
                Vector2 distanceVector = obj.transform.position - transform.position;
                if(distanceVector.magnitude >0)
                {
                    float explosionForce = _explosionForceMulti/distanceVector.magnitude;
                    object_rigidbody.AddForce(distanceVector.normalized * explosionForce);
                }
            }
        }
        _spriteRenderer.enabled = false;
        Destroy(_bombFuse.gameObject);
        bombEffect.SetActive(true);
        Destroy(gameObject, _timeTillBombDestroyed);
    }
    
}
