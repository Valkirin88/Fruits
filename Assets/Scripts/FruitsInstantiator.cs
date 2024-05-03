using System;
using UnityEngine;

public class FruitsInstantiator
{
    private float _instantiationHighPosition = 9f;
    private float _timeBetweenInstantiation = 1f;
    private float _timeAfterInstantiation;

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
        if (_timeAfterInstantiation >= _timeBetweenInstantiation)
        {
            _timeAfterInstantiation = 0;
            _position = new Vector3(pos.x, _instantiationHighPosition, 0);
            _currentPrefab = GetFriut();
            _showedFruit = UnityEngine.Object.Instantiate(_currentPrefab, _position, Quaternion.identity);
            OnFruitInstantiated?.Invoke(_showedFruit);
        }
    }

    private GameObject GetFriut()
    {
        GameObject fruit = _fruitsSet.FruitsPrefabs[UnityEngine.Random.Range(0, _fruitsSet.FruitsPrefabs.Length)];
        return fruit;
    }

    public void Update()
    {
        _timeAfterInstantiation = _timeAfterInstantiation + Time.deltaTime;
    }
}
