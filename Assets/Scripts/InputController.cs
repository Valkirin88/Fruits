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
        float offset = UnityEngine.Random.Range(-0.05f, 0.05f);
        if (offset < 0.01 && offset > -0.01)
            offset = 0.01f * UnityEngine.Random.Range(0, 2) * 2 - 1;

        _worldPosition.x = _worldPosition.x + offset;

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
