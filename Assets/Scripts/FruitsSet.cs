using UnityEngine;

[CreateAssetMenu(fileName = "Fruits", menuName = "ScriptableObjects/SpawnFruitsSet")]
public class FruitsSet : ScriptableObject
{
    [SerializeField]
    private GameObject[] _fruitsSet;

    public GameObject[] FruitsPrefabs => _fruitsSet;
}
