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
    private Toggle _soundToggle;

    private string _defaultName;

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
}
