using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private FruitsSet _fruitsSet;

    private InputController _inputController;
    private FruitsInstantiator _fruitsInstantiator;
    private InstantiatedFruitsCounter _instantiatedFruitsCounter;
    private ScoreCounter _scoreCounter;

    private void Start()
    {
        _inputController = new InputController();
        _fruitsInstantiator = new FruitsInstantiator(_inputController, _fruitsSet);
        _instantiatedFruitsCounter = new InstantiatedFruitsCounter();
        _fruitsInstantiator.OnFruitInstantiated += _instantiatedFruitsCounter.AddToCounter;
        _scoreCounter = new ScoreCounter(_fruitsInstantiator);
    }

    private void Update()
    {
        _inputController.Update();
        _fruitsInstantiator.Update();
    }
}
