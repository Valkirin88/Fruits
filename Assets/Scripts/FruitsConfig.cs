using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fruit", menuName = "ScriptableObjects/Create fruit")]
public class FruitsConfig : ScriptableObject
{
    [SerializeField]
    private GameObject _fruitPrefab;
    [SerializeField]
    private string _fruitName;
}
