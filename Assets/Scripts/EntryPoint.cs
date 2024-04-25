using UnityEngine;

public class EntryPoint : MonoBehaviour
{

    [SerializeField]
    private FruitsSet _fruitsSet;

    private InputController _inputController;
    private FruitsInstantiator _fruitsInstantiator;

    private void Start()
    {
        _inputController = new InputController();
        _fruitsInstantiator = new FruitsInstantiator(_inputController, _fruitsSet);
    }

    private void Update()
    {
        _inputController.Update();
    }

}
