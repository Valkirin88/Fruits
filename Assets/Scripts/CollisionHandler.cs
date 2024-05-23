using System;
using UnityEngine;

public class CollisionHandler 
{
    public event Action<FruitsConfig, Vector3> OnCollisionDone;

    private FruitsInstantiator _fruitsInstantiator;
    private FruitRecipesConfig _fruitRecipesConfig;
    private SpecialEffectsManager _specialEffectsManager;
    private Vector3 _collidedPosition;

    public CollisionHandler(FruitsInstantiator fruitsInstantiator, FruitRecipesConfig fruitRecipesConfig, SpecialEffectsManager specialEffectsManager)
    {
        _fruitsInstantiator = fruitsInstantiator;
        _fruitRecipesConfig = fruitRecipesConfig;
        _specialEffectsManager = specialEffectsManager;
        _fruitsInstantiator.OnFruitInstantiated += SubcribeOnNewFruit;
    }

    private void SubcribeOnNewFruit(Fruit fruit)
    {
        fruit.OnFruitCollided += HandleCollision;
    }

    private void HandleCollision(Fruit fruiteOne, Fruit fruitTwo, Vector3 collidedPosition)
    {
        _collidedPosition = collidedPosition;
        foreach (var recipe in _fruitRecipesConfig.Recipes)
        {
            if (recipe.FruitOne == fruiteOne.FruitsConfig && recipe.FruitTwo == fruitTwo.FruitsConfig)
            {
                
                var _resultFruit = recipe.Result;
                UnityEngine.Object.Destroy(fruiteOne.gameObject);
                UnityEngine.Object.Destroy(fruitTwo.gameObject);
                _fruitsInstantiator.ProduceFruit(_resultFruit, _collidedPosition);
                _specialEffectsManager.ShowCollision(collidedPosition);
                //OnCollisionDone?.Invoke(_resultFruit, _collidedPosition);
            }
            else
            {
                fruiteOne.IsCollided = false;
                fruitTwo.IsCollided = false;
            }
        }
    }


}
