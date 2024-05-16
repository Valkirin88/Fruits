using UnityEngine;

[CreateAssetMenu(fileName = "Fruits", menuName = "ScriptableObjects/SpawnFruitsSet")]
public class FruitsSet : ScriptableObject
{
    [SerializeField]
    private FruitsConfig[] _fruitsSet;

    public FruitsConfig[] Fruits => _fruitsSet;
}
