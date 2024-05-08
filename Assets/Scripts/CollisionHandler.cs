using UnityEngine;

public class CollisionHandler 
{
    private FruitsInstantiator _fruitsInstantiator;
    private FruitRecipesConfig _fruitRecipesConfig;
    private GameObject _firstCollidedFruit;
    private GameObject _secondCollidedFruit;
    private FruitsConfig _resultFruit;
    private Vector3 _collidedPosition;

    public CollisionHandler(FruitsInstantiator fruitsInstantiator, FruitRecipesConfig fruitRecipesConfig)
    {
        _fruitsInstantiator = fruitsInstantiator;

        _fruitsInstantiator.OnFruitInstantiated += SubcribeOnNewFruit;
    }

    private void SubcribeOnNewFruit(Fruit fruit)
    {
        fruit.OnFruitCollided += HandleCollision;
    }

    private void HandleCollision(GameObject fruiteOne, GameObject fruitTwo, Vector3 collidedPosition)
    {
        _firstCollidedFruit = fruiteOne;
        _secondCollidedFruit = fruitTwo;
        _collidedPosition = collidedPosition;
        MergedFruits();
    }

    private void MergedFruits()
    {
        foreach(var recipe in _fruitRecipesConfig.Recipes) 
        {
            if (recipe.FruitOne == _firstCollidedFruit && recipe.FruitTwo == _secondCollidedFruit)
                _resultFruit = recipe.Result;
        }
        Object.Destroy(_firstCollidedFruit);
        Object.Destroy(_secondCollidedFruit);
        _fruitsInstantiator.ProduceFruit(_resultFruit, _collidedPosition);
    }
}
