using System;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private Button _instantiateButton;

    public Action<Vector3> OnTouched;

    private Vector3 _mousePosition;
    private Vector3 _worldPosition;

    private float _timeBetweenTouches = 1.1f;
    private float _timeAfterTouchs = 0.5f;

    public void Start()
    {
        _instantiateButton.onClick.AddListener(CheckPushedButtons);
    }

    private void Update()
    {
        _timeAfterTouchs += Time.deltaTime;
    }

    private void CheckPushedButtons()
    {
        if (_timeAfterTouchs >= _timeBetweenTouches)
        {
            _timeAfterTouchs = 0;
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

    private void OnDestroy()
    {
        _instantiateButton.onClick.RemoveListener(CheckPushedButtons);
    }
}
