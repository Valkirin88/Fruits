using System;
using UnityEngine;


public class CollisionHandler 
{
    public event Action OnCollisionDone;
    public event Action OnFruictsCollided;

    private FruitsInstantiator _fruitsInstantiator;
    private FruitRecipesConfig _fruitRecipesConfig;
    private SpecialEffectsManager _specialEffectsManager;

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

    private void HandleCollision(Fruit fruitOne, Fruit fruitTwo, Vector3 collidedPosition)
    {

        if (fruitOne.IsCollided || fruitTwo.IsCollided)
            return;
        if (TryGetRecipe(fruitOne, fruitTwo, out Recipe recipe))
        {
            fruitOne.IsCollided = true;
            fruitTwo.IsCollided = true;
            var _resultFruit = recipe.Result;
            UnityEngine.Object.Destroy(fruitOne.gameObject);
            UnityEngine.Object.Destroy(fruitTwo.gameObject);
            _fruitsInstantiator.ProduceFruit(_resultFruit, collidedPosition);
            _specialEffectsManager.ShowCollision(collidedPosition);
            OnCollisionDone?.Invoke();
            return;
        }
    }

    private bool TryGetRecipe(Fruit fruitOne, Fruit fruitTwo, out Recipe recipe)
    {
        foreach (var r in _fruitRecipesConfig.Recipes)
        {
            if (r.FruitOne == fruitOne.FruitsConfig && r.FruitTwo == fruitTwo.FruitsConfig)
            {
                recipe = r;
                return true;
            }
        }
        recipe = null;
        return false;
    }
}
