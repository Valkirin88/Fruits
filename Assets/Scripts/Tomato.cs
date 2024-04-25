using UnityEngine;

public class Tomato : MonoBehaviour, IFruit
{
    [SerializeField]
    private GameObject _orangePrefab;

    [HideInInspector]
    public float LifeDuration;

    private GameObject _orange;

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Tomato>() != null)
        {
            if (LifeDuration > col.gameObject.GetComponent<Tomato>().LifeDuration)
            {       
                _orange = Instantiate(_orangePrefab, col.transform.position, Quaternion.identity);
                _orange.transform.SetParent(null);
            }
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        LifeDurationTimer();
    }
    public void LifeDurationTimer()
    {
        LifeDuration += Time.deltaTime;
    }
}
