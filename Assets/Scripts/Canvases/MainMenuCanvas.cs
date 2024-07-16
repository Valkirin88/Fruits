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
    [SerializeField]
    private Image _soundButtonImage;
    [SerializeField]
    private Sprite _soundOnSprite;
    [SerializeField]
    private Sprite _soundOffSprite;

    void Start()
    {
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("Name")))
        {
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
        ChangeSoundButtonSprite(GameInfo.SwitchSound());
    }

    private void ChangeSoundButtonSprite(bool IsSoundOn)
    {
        if (IsSoundOn)
        {
            _soundButtonImage.sprite = _soundOnSprite;
        }
        else
            _soundButtonImage.sprite = _soundOffSprite;
    }

    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(StartGame);
        _leaderboardButton.onClick.RemoveListener(ShowLeaderboard);
        _soundButton.onClick.RemoveListener(SwitchSound);
    }
}
