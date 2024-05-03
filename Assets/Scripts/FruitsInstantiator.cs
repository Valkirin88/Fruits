using System;
using UnityEngine;

public class FruitsInstantiator
{

    private float _instantiationHighPosition = 15f;

    private InputController _inputController;
    private FruitsSet _fruitsSet;

    private GameObject _currentPrefab;
    private GameObject _showedFruit;

    private Vector3 _position;

    public Action<GameObject> OnFruitInstantiated;

    public FruitsInstantiator(InputController inputController, FruitsSet fruitsSet)
    {
        _inputController = inputController;
        _fruitsSet = fruitsSet;
        _inputController.OnTouched += ProduceFruit;
    }

    private void ProduceFruit(Vector3 pos)
    {
        _position = new Vector3(pos.x, _instantiationHighPosition, 0);
        _currentPrefab = GetFriut();
        _showedFruit = UnityEngine.Object.Instantiate(_currentPrefab, _position, Quaternion.identity);
        OnFruitInstantiated?.Invoke(_showedFruit);
    }

    private GameObject GetFriut()
    {
        GameObject fruit = _fruitsSet.FruitsPrefabs[UnityEngine.Random.Range(0, _fruitsSet.FruitsPrefabs.Length)];
        return fruit;
    }
}
