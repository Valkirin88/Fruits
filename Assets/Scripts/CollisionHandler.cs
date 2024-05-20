using UnityEngine;

public class CollisionHandler 
{
    private FruitsInstantiator _fruitsInstantiator;
    private FruitRecipesConfig _fruitRecipesConfig;
    private Vector3 _collidedPosition;

    public CollisionHandler(FruitsInstantiator fruitsInstantiator, FruitRecipesConfig fruitRecipesConfig)
    {
        _fruitsInstantiator = fruitsInstantiator;
        _fruitRecipesConfig = fruitRecipesConfig;

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
                Object.Destroy(fruiteOne.gameObject);
                Object.Destroy(fruitTwo.gameObject);
                _fruitsInstantiator.ProduceFruit(_resultFruit, _collidedPosition);
            }
        }
    }
}
