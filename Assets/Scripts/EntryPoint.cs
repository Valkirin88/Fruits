using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private FruitsSet _fruitsSet;
    [SerializeField]
    private FruitRecipesConfig _fruitRecipesConfig;
    [SerializeField]
    private GameCanvas _gameCanvas;
    [SerializeField]
    private GameOverZone _gameOverZone;
    [SerializeField]
    private SpecialEffectsManager _specialEffectsManager;
    [SerializeField]
    private SoundsHandler _soundsHandler;
    [SerializeField]
    private MainZone _mainZone;


    private InputController _inputController;
    private FruitsInstantiator _fruitsInstantiator;
    private InstantiatedFruitsCounter _instantiatedFruitsCounter;
    private ScoreHandler _scoreCounter;
    private CollisionHandler _collisionHandler;
    private FruitPusher _fruitPusher;
    private FruitCountDown _fruitCountDown;

    private void Awake()
    {
        UnityEngine.Time.timeScale = 1;
        _inputController = new InputController();
        _fruitsInstantiator = new FruitsInstantiator(_inputController, _fruitsSet);
        _instantiatedFruitsCounter = new InstantiatedFruitsCounter();
        _fruitsInstantiator.OnFruitInstantiated += _instantiatedFruitsCounter.AddToCounter;
        _scoreCounter = new ScoreHandler(_fruitsInstantiator, _gameCanvas);
        _collisionHandler = new CollisionHandler(_fruitsInstantiator, _fruitRecipesConfig, _specialEffectsManager);
        _fruitCountDown = new FruitCountDown();
        _gameOverZone.Initialize(_fruitCountDown);
        _gameCanvas.Initialize(_scoreCounter, _fruitsInstantiator, _fruitCountDown);
        _mainZone.Initialize(_fruitCountDown);
        _fruitPusher = new FruitPusher(_fruitsInstantiator);
        _soundsHandler.Initialize(_fruitsInstantiator, _collisionHandler);
    }

    private void Update()
    {
        _inputController.Update();
        _fruitsInstantiator.Update();
        _fruitCountDown.Update();
        _scoreCounter.Update();
    }

    private void OnDestroy()
    {
        _fruitsInstantiator.Destroy();
    }
}
