using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvas : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private Button _leaderboardButton;

    [SerializeField]
    private Button _soundButton;

    void Start()
    {
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("Name")))
        {
            Debug.Log("name screen");
            SceneManager.LoadSceneAsync(1);
        }
        else
        {
            _startButton.onClick.AddListener(StartGame);
            _leaderboardButton.onClick.AddListener(ShowLeaderboard);
            _soundButton.onClick.AddListener(SwitchSound);
        }
    }

    private void StartGame()
    {
        SceneManager.LoadSceneAsync(3);
    }

    private void ShowLeaderboard()
    {
        SceneManager.LoadSceneAsync(2);
    }

    private void SwitchSound()
    {
        GameInfo.SwitchSound();
    }

    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(StartGame);
        _leaderboardButton.onClick.RemoveListener(ShowLeaderboard);
        _soundButton.onClick.RemoveListener(SwitchSound);
    }
}
