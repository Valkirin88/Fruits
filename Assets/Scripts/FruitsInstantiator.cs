using System;
using UnityEngine;

public class FruitsInstantiator: IDisposable
{
    public event Action<Fruit> OnFruitInstantiated;
    public event Action<FruitsConfig> OnNextFruitGot;
    public event Action OnFruitInstantiatedAtTop;
    public event Action<Bomb> OnBombInstantiated;

    private float _timeBetweenInstantiation = 0.8f;
    private float _timeAfterInstantiation = 0.5f;

    private FruitsConfig _currentFruit;
    private FruitsConfig _nextFruit;

    private InputController _inputController;
    private FruitsSet _fruitsSet;
    private Lemur _lemur;

    private GameObject _showedFruit;


    public FruitsConfig NextFruit => _nextFruit;

    public FruitsInstantiator(InputController inputController, FruitsSet fruitsSet, Lemur lemur)
    {
        _inputController = inputController;
        _fruitsSet = fruitsSet;
        _lemur = lemur; 
        //_inputController.OnTouched += ProduceFruit;
        _lemur.OnLemurStartedMoving += ProduceFruit;
        _currentFruit = GetFriut();
        _nextFruit = GetFriut();
    }

    private void ProduceFruit(Lemur lemur)
    {
        if (_timeAfterInstantiation >= _timeBetweenInstantiation)
        {

            ChangeFruit();
            _timeAfterInstantiation = 0;
            var position = lemur.GrabTransform.position;
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
        
        fruit.Construct(mergedfruit);
        OnFruitInstantiated?.Invoke(fruit);
        if (fruit.TryGetComponent<Bomb>(out Bomb bomb))
        {
            OnBombInstantiated?.Invoke(bomb);
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

    public void Dispose()
    {
        // _inputController.OnTouched -= ProduceFruit;
        _lemur.OnLemurStartedMoving -= ProduceFruit;
    }
}
