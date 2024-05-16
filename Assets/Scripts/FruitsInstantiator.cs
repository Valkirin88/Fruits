using System;
using UnityEngine;

public class FruitsInstantiator
{
    private float _instantiationHighPosition = 9f;
    private float _timeBetweenInstantiation = 0.5f;
    private float _timeAfterInstantiation = 0.5f;

    private InputController _inputController;
    private FruitsSet _fruitsSet;

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
            var config = GetFriut();
            ProduceFruit(config, _position);
    }
    public void ProduceFruit(FruitsConfig mergedfruit, Vector3 pos)
    {
        if (_timeAfterInstantiation >= _timeBetweenInstantiation)
        {
            _timeAfterInstantiation = 0;
            _position = new Vector3(pos.x, _instantiationHighPosition, 0);
            _showedFruit = UnityEngine.Object.Instantiate(mergedfruit.FruitPrefab, _position, Quaternion.identity);
            var fruit = _showedFruit.GetComponent<Fruit>();
            fruit.Construct(mergedfruit);
            OnFruitInstantiated?.Invoke(fruit);
        }
    }

    private FruitsConfig GetFriut()
    {
        var fruit = _fruitsSet.Fruits[UnityEngine.Random.Range(0, _fruitsSet.Fruits.Length)];
        return fruit;
    }

    public void Update()
    {
        _timeAfterInstantiation = _timeAfterInstantiation + Time.deltaTime;
    }
}
