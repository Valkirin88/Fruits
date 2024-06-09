using UnityEngine;

[CreateAssetMenu(fileName = "Fruit", menuName = "ScriptableObjects/Create fruit")]
public class FruitsConfig : ScriptableObject
{
    [SerializeField]
    private GameObject _fruitPrefab;
    [SerializeField]
    private string _fruitName;
    [SerializeField]
    private int _score;
    [SerializeField]
    private Sprite _sprite;

    public GameObject FruitPrefab => _fruitPrefab;
    public int Score => _score;
    public Sprite Sprite => _sprite;
}
