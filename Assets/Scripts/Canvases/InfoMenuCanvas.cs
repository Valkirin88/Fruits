using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoMenuCanvas : MonoBehaviour
{
    [SerializeField]
    private Button _backButton;

    private void Start()
    {
        _backButton.onClick.AddListener(ShowMainMenu);
    }

    private void ShowMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        _backButton.onClick.RemoveListener(ShowMainMenu);
    }
}
