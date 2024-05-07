using System;
using UnityEngine;

public class FruitsInstantiator
{
    private float _instantiationHighPosition = 9f;
    private float _timeBetweenInstantiation = 0.5f;
    private float _timeAfterInstantiation = 0.5f;

    private InputController _inputController;
    private FruitsSet _fruitsSet;

    private GameObject _currentPrefab;
    private GameObject _showedFruit;

    private Vector3 _position;

    public Action<Fruit> OnFruitInstantiated;

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
            var fruit = _showedFruit.GetComponent<Fruit>();
            OnFruitInstantiated?.Invoke(fruit);
        }
    }
    public void ProduceFruit(Fruit mergedfruit, Vector3 pos)
    {
        if (_timeAfterInstantiation >= _timeBetweenInstantiation)
        {
            _timeAfterInstantiation = 0;
            _position = new Vector3(pos.x, _instantiationHighPosition, 0);
            _currentPrefab = GetFriut();
            _showedFruit = UnityEngine.Object.Instantiate(_currentPrefab, _position, Quaternion.identity);
            var fruit = _showedFruit.GetComponent<Fruit>();
            OnFruitInstantiated?.Invoke(fruit);
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
