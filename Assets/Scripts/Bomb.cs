using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private GameObject bombEffect;

    private float _explosionRadius = 50;
    private float _explosionForceMulti = 1000000;
    private Collider2D[] _colliders;


    private void Start()
    {
        Invoke("Explode", 2f);
    }

    private void Explode()
    {
        Debug.Log("explode");
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
                    Debug.Log("explode");
                }
            }
        }
        bombEffect.SetActive(true);
        Destroy(gameObject,0.5f);
    }
    
}
