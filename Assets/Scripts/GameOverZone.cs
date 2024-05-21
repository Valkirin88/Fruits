using System;
using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    [SerializeField]
    private float _timeTillGameOver = 3f;

    public event Action OnGameOver;

    private float _timeInGameOverZone;
    private bool _isCounting = false;
    private GameObject _currentFruitObject;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Fruit>())
        {
            _currentFruitObject = collision.gameObject;
            _isCounting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (_currentFruitObject = collision.gameObject)
        {
            _timeInGameOverZone = 0;
            _isCounting = false;
        }
    }

    private void Update()
    {
        Debug.Log(_timeInGameOverZone);
        if (_isCounting)
        {
            _timeInGameOverZone += Time.deltaTime;
            if (_timeInGameOverZone >= _timeTillGameOver)
            {
                Debug.Log("GameOver");
                OnGameOver?.Invoke();
            }
        }
    }
}
