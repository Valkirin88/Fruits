using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvas : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private Button _leaderboardButton;

    void Start()
    {
        _startButton.onClick.AddListener(StartGame);
        _leaderboardButton.onClick.AddListener(ShowLeaderboard);
    }

    private void StartGame()
    {
        SceneManager.LoadSceneAsync(0);
    }

    private void ShowLeaderboard()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
