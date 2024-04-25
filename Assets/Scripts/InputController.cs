using System;
using UnityEngine;

public class InputController
{
    public Action<Vector3> OnTouched;

    private Vector3 _mousePosition;
    private Vector3 _worldPosition;



    public void Update()
    {
        CheckPushedButtons();
    }

    private void CheckPushedButtons()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePosition = Input.mousePosition;
            _mousePosition.z = Camera.main.nearClipPlane;
            _worldPosition = Camera.main.ScreenToWorldPoint(_mousePosition);
            AddRandomOffset(ref _worldPosition);
            OnTouched?.Invoke(_worldPosition);
            
            
        }
    }

    private void AddRandomOffset(ref Vector3 _worldPosition)
    {
        _worldPosition.x = _worldPosition.x + (UnityEngine.Random.Range(-0.01f, 0.01f));
    }


    //private void CheckPushedButtons()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            _touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
    //            Debug.Log(_touchPosition);
    //            OnTouched?.Invoke(_touchPosition);
    //        }
    //    }
    //}
}
