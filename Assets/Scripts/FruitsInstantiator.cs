using System;
using UnityEngine;

public class FruitsInstantiator: IDisposable
{
    public event Action<Fruit> OnFruitInstantiated;
    public event Action<FruitsConfig> OnNextFruitGot;
    public event Action OnFruitInstantiatedAtTop;
    public event Action<Bomb> OnBombInstantiated;

    private FruitsConfig _currentFruit;
    private FruitsConfig _nextFruit;

    private FruitsSet _fruitsSet;
    private Lemur _lemur;

    private GameObject _showedFruit;


    public FruitsConfig NextFruit => _nextFruit;

    public FruitsInstantiator(FruitsSet fruitsSet, Lemur lemur)
    {
        _fruitsSet = fruitsSet;
        _lemur = lemur; 
        _lemur.OnLemurStartedMoving += ProduceFruit;
        _lemur.OnLemurAtLowPosition += UnlinkFruit;
        _currentFruit = GetFriut();
        _nextFruit = GetFriut();
    }

    private void ProduceFruit()
    {
        ChangeFruit();
        var position = _lemur.GrabTransform.position;
        OnFruitInstantiatedAtTop?.Invoke();
        _showedFruit = UnityEngine.Object.Instantiate(_currentFruit.FruitPrefab);
        _showedFruit.transform.SetParent(_lemur.GrabTransform, true);
        _showedFruit.transform.position = _lemur.GrabTransform.position;
        var fruit = _showedFruit.GetComponent<Fruit>();
        fruit.Construct(_currentFruit);
        OnFruitInstantiated?.Invoke(fruit);
    }
    public void ProduceFruitAfterMerge(FruitsConfig mergedfruit, Vector3 pos)
    {
        var position = pos;
        _showedFruit = UnityEngine.Object.Instantiate(mergedfruit.FruitPrefab, position, Quaternion.identity);
        var fruit = _showedFruit.GetComponent<Fruit>();
        fruit.Construct(mergedfruit);
        OnFruitInstantiated?.Invoke(fruit);
        if (fruit.TryGetComponent<Bomb>(out Bomb bomb))
        {
            OnBombInstantiated?.Invoke(bomb);
        }
    }

    private void UnlinkFruit()
    {
        _showedFruit.transform.SetParent(null);
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

    public void Dispose()
    {
        _lemur.OnLemurStartedMoving -= ProduceFruit;
        _lemur.OnLemurAtLowPosition -= UnlinkFruit;
    }
}
