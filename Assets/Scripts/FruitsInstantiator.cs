using UnityEngine;

public class FruitsInstantiator
{
    private InputController _inputController;
    private FruitsSet _fruitsSet;

    private GameObject _currentPrefab;
    private GameObject _showedFruit;

    private Vector3 _position;

    public FruitsInstantiator(InputController inputController, FruitsSet fruitsSet)
    {
        _inputController = inputController;
        _fruitsSet = fruitsSet;
        _inputController.OnTouched += ProduceFruit;
    }

    private void ProduceFruit(Vector3 pos)
    {
        _position = new Vector3(pos.x, pos.y, 0);
        _currentPrefab = GetFriut();
        _showedFruit = Object.Instantiate(_currentPrefab, _position, Quaternion.identity);
    }

    private GameObject GetFriut()
    {
        GameObject fruit = _fruitsSet.FruitsPrefabs[Random.Range(0, _fruitsSet.FruitsPrefabs.Length)];
        return fruit;
    }
}
