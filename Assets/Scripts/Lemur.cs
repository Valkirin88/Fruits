using System;
using UnityEngine;
using DG.Tweening;

public class Lemur : MonoBehaviour
{
    [SerializeField]
    private Transform _grabTransform;

    public event Action<Lemur> OnLemurStartedMoving;

    private InputController _inputController;

    private Sequence _sequence;
    private Vector3 _originalPosition;

    public Transform GrabTransform  => _grabTransform; 

    public void Initialize(InputController inputController)
    {
        _inputController = inputController;
        _inputController.OnTouched += LemurMoveToPosition;
        
        _originalPosition = transform.position;
    }

    private void LemurMoveToPosition(Vector3 position)
    {
        OnLemurStartedMoving?.Invoke(this);

        _sequence = DOTween.Sequence();
        Vector3 lowPosition = new Vector3(position.x, GameInfo.InstantiationHighPosition, 0);
        

        transform.position = new Vector3(position.x, transform.position.y, 0);
        Vector3 highPosition = new Vector3(position.x, _originalPosition.y, 0);
        _sequence.Append(transform.DOMove(lowPosition, 0.5f)).OnComplete(LemurInLowPosition).Append(transform.DOMove(highPosition, 0.5f));
        _sequence.Play();

    }

    private void LemurInLowPosition()
    {
    
    }

    private void OnDestroy()
    {
        _inputController.OnTouched -= LemurMoveToPosition;
    }
}
