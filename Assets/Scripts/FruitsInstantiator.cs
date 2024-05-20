using System;
using UnityEngine;

public class FruitsInstantiator
{
    public Action<Fruit> OnFruitInstantiated;
    public event Action<FruitsConfig> OnNextFruitShown;

    private float _instantiationHighPosition = 9f;
    private float _timeBetweenInstantiation = 0.6f;
    private float _timeAfterInstantiation = 0.5f;
    private bool _isFuitCurrent;
    private FruitsConfig _currentFruit;
    private FruitsConfig _nextFruit;

    private InputController _inputController;
    private FruitsSet _fruitsSet;

    private GameObject _showedFruit;

    public FruitsInstantiator(InputController inputController, FruitsSet fruitsSet)
    {
        _inputController = inputController;
        _fruitsSet = fruitsSet;
        _inputController.OnTouched += ProduceFruit;
        _currentFruit = GetFriut();
        _nextFruit = GetFriut();
    }

    private void ProduceFruit(Vector3 pos)
    {
        if (_timeAfterInstantiation >= _timeBetweenInstantiation)
        {
            _timeAfterInstantiation = 0;
            var position = new Vector3(pos.x, _instantiationHighPosition, 0);
            ProduceFruit(_currentFruit, position);
        }
    }
    public void ProduceFruit(FruitsConfig mergedfruit, Vector3 pos)
    {
        var position = pos;
        _showedFruit = UnityEngine.Object.Instantiate(mergedfruit.FruitPrefab, position, Quaternion.identity);
        var fruit = _showedFruit.GetComponent<Fruit>();
        fruit.Construct(mergedfruit);
        OnFruitInstantiated?.Invoke(fruit);
        ChangeFruit();
    }

    public void ChangeFruit() 
    {
        _currentFruit = _nextFruit;
        _nextFruit = GetFriut();
    }

    private FruitsConfig GetFriut()
    {
        var fruit = _fruitsSet.Fruits[UnityEngine.Random.Range(0, _fruitsSet.Fruits.Length)];
        OnNextFruitShown?.Invoke(fruit);
        return fruit;
    }

    public void Update()
    {
        _timeAfterInstantiation = _timeAfterInstantiation + Time.deltaTime;
    }
}
