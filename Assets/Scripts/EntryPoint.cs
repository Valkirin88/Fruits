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
    [SerializeField]
    private VibrationHandler _vibrationHandler;



    private InputController _inputController;
    private FruitsInstantiator _fruitsInstantiator;
    private InstantiatedFruitsCounter _instantiatedFruitsCounter;
    private ScoreHandler _scoreCounter;
    private CollisionHandler _collisionHandler;
    private FruitPusher _fruitPusher;
    private FruitCountDown _fruitCountDown;
    private FruitsContainer _fruitsContainer;
    private FruitBlinker _fruitBlinker;
    private SmilesHandler _smilesHandler;
    private FruitLifeTimeCounter _fruitLifeTimeCounter;


    private void Awake()
    {
        _inputController = new InputController();
        _fruitsInstantiator = new FruitsInstantiator(_inputController, _fruitsSet);
        _instantiatedFruitsCounter = new InstantiatedFruitsCounter();
        _fruitsInstantiator.OnFruitInstantiated += _instantiatedFruitsCounter.AddToCounter;
        _scoreCounter = new ScoreHandler(_fruitsInstantiator, _gameCanvas);
        _collisionHandler = new CollisionHandler(_fruitsInstantiator, _fruitRecipesConfig, _specialEffectsManager);
        _fruitCountDown = new FruitCountDown(_fruitsInstantiator);
        _gameOverZone.Initialize(_fruitCountDown);
        _gameCanvas.Initialize(_scoreCounter, _fruitsInstantiator, _fruitCountDown);
        _mainZone.Initialize(_fruitCountDown);
        _fruitPusher = new FruitPusher(_fruitsInstantiator);
        _soundsHandler.Initialize(_fruitsInstantiator, _collisionHandler);
        _fruitsContainer = new FruitsContainer(_fruitsInstantiator);
        _fruitBlinker = new FruitBlinker(_fruitsContainer);
        _smilesHandler = new SmilesHandler(_fruitsContainer);
        _vibrationHandler.Initialize(_collisionHandler, _fruitsInstantiator);
        _fruitLifeTimeCounter = new FruitLifeTimeCounter(_fruitsContainer);
    }

    private void Update()
    {
        _inputController.Update();
        _fruitsInstantiator.Update();
        _fruitCountDown.Update();
        _scoreCounter.Update();
        _fruitBlinker.Update();
        _smilesHandler.Update();
        _fruitLifeTimeCounter.Update();
    }

    private void OnDestroy()
    {
        _fruitsInstantiator.Destroy();
        _fruitsContainer.Destroy();
        _fruitCountDown.Destroy();
    }
}
