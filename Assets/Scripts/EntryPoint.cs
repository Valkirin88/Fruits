using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private FruitsSet _fruitsSet;
    [SerializeField]
    private FruitRecipesConfig _fruitRecipesConfig;
    [SerializeField]
    private CanvasHandler _canvasHandler;
    [SerializeField]
    private GameOverZone _gameOverZone;
    [SerializeField]
    private SpecialEffectsManager _specialEffectsManager;

    private InputController _inputController;
    private FruitsInstantiator _fruitsInstantiator;
    private InstantiatedFruitsCounter _instantiatedFruitsCounter;
    private ScoreCounter _scoreCounter;
    private CollisionHandler _collisionHandler;
    private FruitPusher _fruitPusher;

    private void Awake()
    {
        UnityEngine.Time.timeScale = 1;
        _inputController = new InputController();
        _fruitsInstantiator = new FruitsInstantiator(_inputController, _fruitsSet);
        _instantiatedFruitsCounter = new InstantiatedFruitsCounter();
        _fruitsInstantiator.OnFruitInstantiated += _instantiatedFruitsCounter.AddToCounter;
        _scoreCounter = new ScoreCounter(_fruitsInstantiator);
        _collisionHandler = new CollisionHandler(_fruitsInstantiator, _fruitRecipesConfig, _specialEffectsManager);
        _canvasHandler.Initialize(_scoreCounter, _fruitsInstantiator, _gameOverZone);
        _fruitPusher = new FruitPusher(_fruitsInstantiator);
    }

    private void Update()
    {
        _inputController.Update();
        _fruitsInstantiator.Update();
    }

    private void OnDestroy()
    {
        _fruitsInstantiator.Destroy();
    }
}
