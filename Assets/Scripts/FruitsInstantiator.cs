using System;
using UnityEngine;

public class FruitsInstantiator
{
    private float _instantiationHighPosition = 9f;
    private float _timeBetweenInstantiation = 0.6f;
    private float _timeAfterInstantiation = 0.5f;

    private InputController _inputController;
    private FruitsSet _fruitsSet;

    private GameObject _showedFruit;

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
            var config = GetFriut();
            var position = new Vector3(pos.x, _instantiationHighPosition, 0);
            ProduceFruit(config, position);
        }
    }
    public void ProduceFruit(FruitsConfig mergedfruit, Vector3 pos)
    {
        var position = pos;
        _showedFruit = UnityEngine.Object.Instantiate(mergedfruit.FruitPrefab, position, Quaternion.identity);
        var fruit = _showedFruit.GetComponent<Fruit>();
        fruit.Construct(mergedfruit);
        OnFruitInstantiated?.Invoke(fruit);
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
