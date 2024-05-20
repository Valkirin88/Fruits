using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private FruitsSet _fruitsSet;
    [SerializeField]
    private FruitRecipesConfig _fruitRecipesConfig;
    [SerializeField]
    private CanvasHandler _canvasHandler;

    private InputController _inputController;
    private FruitsInstantiator _fruitsInstantiator;
    private InstantiatedFruitsCounter _instantiatedFruitsCounter;
    private ScoreCounter _scoreCounter;
    private CollisionHandler _collisionHandler;

    private void Start()
    {
        _inputController = new InputController();
        _fruitsInstantiator = new FruitsInstantiator(_inputController, _fruitsSet);
        _instantiatedFruitsCounter = new InstantiatedFruitsCounter();
        _fruitsInstantiator.OnFruitInstantiated += _instantiatedFruitsCounter.AddToCounter;
        _scoreCounter = new ScoreCounter(_fruitsInstantiator);
        _collisionHandler = new CollisionHandler(_fruitsInstantiator, _fruitRecipesConfig);
        _canvasHandler.Initialize(_scoreCounter);
    }

    private void Update()
    {
        _inputController.Update();
        _fruitsInstantiator.Update();
    }
}
