using System;
using UnityEngine;

public class FruitsInstantiator
{
    public event Action<Fruit> OnFruitInstantiated;
    public event Action<FruitsConfig> OnNextFruitGot;
    public event Action OnFruitInstantiatedAtTop;
    public event Action OnBombInstantiated;

    private float _instantiationHighPosition = 15f;
    private float _timeBetweenInstantiation = 0.8f;
    private float _timeAfterInstantiation = 0.5f;
    private bool _isFuitCurrent;
    private FruitsConfig _currentFruit;
    private FruitsConfig _nextFruit;

    private InputController _inputController;
    private FruitsSet _fruitsSet;

    private GameObject _showedFruit;

    public FruitsConfig NextFruit => _nextFruit; 

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
            ChangeFruit();
            _timeAfterInstantiation = 0;
            var position = new Vector3(pos.x, _instantiationHighPosition, 0);
            OnFruitInstantiatedAtTop?.Invoke();
            ProduceFruit(_currentFruit, position);
        }
    }
    public void ProduceFruit(FruitsConfig mergedfruit, Vector3 pos)
    {
        var position = pos;
        _showedFruit = UnityEngine.Object.Instantiate(mergedfruit.FruitPrefab, position, Quaternion.identity);
        var fruit = _showedFruit.GetComponent<Fruit>();
        var rigidBody = _showedFruit.GetComponent<Rigidbody2D>();
        
        fruit.Construct(mergedfruit, GameInfo.GetFruitNumber());
        OnFruitInstantiated?.Invoke(fruit);
        if (fruit.GetComponent<Bomb>())
        {
            OnBombInstantiated?.Invoke();
        }

    }

    public void ChangeFruit() 
    {
        _currentFruit = NextFruit;
        _nextFruit = GetFriut();
    }

    private FruitsConfig GetFriut()
    {
        var fruit = _fruitsSet.Fruits[UnityEngine.Random.Range(0, _fruitsSet.Fruits.Length)];
        OnNextFruitGot?.Invoke(fruit);
        return fruit;
    }

    public void Update()
    {
        _timeAfterInstantiation = _timeAfterInstantiation + Time.deltaTime;
    }

    public void Destroy()
    {
        _inputController.OnTouched -= ProduceFruit;
    }
}
