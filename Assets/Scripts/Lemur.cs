using System;
using UnityEngine;
using DG.Tweening;

public class Lemur : MonoBehaviour
{
    [SerializeField]
    private Transform _grabTransform;

    public event Action OnLemurStartedMoving;
    public event Action OnLemurAtLowPosition;

    private InputController _inputController;

    private Vector3 _originalPosition;
    private Vector3 _lowPosition;
    private Vector3 _highPosition;

    public Transform GrabTransform  => _grabTransform; 

    public void Initialize(InputController inputController)
    {
        _inputController = inputController;
        _inputController.OnTouched += LemurMoveToPosition;
        
        _originalPosition = transform.position;
    }

    private void LemurMoveToPosition(Vector3 position)
    {
        OnLemurStartedMoving?.Invoke();

        _lowPosition = new Vector3(position.x, GameInfo.InstantiationHighPosition, 0);
        

        transform.position = new Vector3(position.x, transform.position.y, 0);
        _highPosition = new Vector3(position.x, _originalPosition.y, 0);
        transform.DOMove(_lowPosition, 0.5f).OnComplete(LemurInLowPosition);
    }

    private void LemurInLowPosition()
    {
        OnLemurAtLowPosition?.Invoke();
        transform.DOMove(_highPosition, 0.5f);
    }

    private void OnDestroy()
    {
        _inputController.OnTouched -= LemurMoveToPosition;
    }
}
