using System;
using System.Collections.Generic;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    [SerializeField]
    private float _timeTillGameOver = 3f;

    public event Action OnGameOver;

    private float _timeInGameOverZone;
    private bool _isCounting = false;
    private GameObject _currentFruitObject;
    private List<Fruit> _fruits;

    private void Start()
    {
        _fruits = new List<Fruit>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Fruit>(out Fruit fruit))
        {
            _fruits.Add(fruit);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Fruit>(out Fruit fruit))
        {
            _fruits.Remove(fruit);
        }
    }

    private void Update()
    {
        if (_fruits.Count > 0)
        {
            _timeInGameOverZone += Time.deltaTime;
            if (_timeInGameOverZone >= _timeTillGameOver)
            {
                Debug.Log(_timeInGameOverZone);
                OnGameOver?.Invoke();
            }
        }
        else
            _timeInGameOverZone = 0;
    }
}
