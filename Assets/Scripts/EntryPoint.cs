using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private FruitsSet _fruitsSet;
    [SerializeField]
    private FruitsContainer _fruitContainer;

    private InputController _inputController;
    private FruitsInstantiator _fruitsInstantiator;
    private InstantiatedFruitsCounter _instantiatedFruitsCounter;

    private void Start()
    {
        _inputController = new InputController();
        _fruitsInstantiator = new FruitsInstantiator(_inputController, _fruitsSet);
        _instantiatedFruitsCounter = new InstantiatedFruitsCounter();
        _fruitsInstantiator.OnFruitInstantiated += _instantiatedFruitsCounter.AddToCounter;
        _fruitContainer.InstantiatedFruitsCounter = _instantiatedFruitsCounter.FruitsCounter;
    }

    private void Update()
    {
        _inputController.Update();
    }
}
