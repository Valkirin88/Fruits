using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeConfig", menuName = "ScriptableObjects/Create recipe config")]
public class FruitRecipesConfig : ScriptableObject
{
    [SerializeField]
    private List<Recipe> _recipes;

    public List<Recipe> Recipes => _recipes; 
}


