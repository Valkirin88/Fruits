using UnityEngine;

public class BombFuse : MonoBehaviour
{
    [SerializeField]
    private GameObject _bombLight;

    [SerializeField]
    private Transform _fuseTargetPosition;

    private void Update()
    {
        _bombLight.transform.position = Vector3.MoveTowards(_bombLight.transform.position, _fuseTargetPosition.position, 0.5f * Time.deltaTime);
    }
}
