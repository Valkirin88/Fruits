using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameCanvas : MonoBehaviour
{
    public event Action OnGameOverShowd;

    //Texts
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private GameObject _dangerTextObject;
    //Images
    [SerializeField]
    private Image _nextFruitImage;
    [SerializeField]
    private GameObject _gameOverObject;
    //Buttons
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private GameObject _restartButtonObject;
    [SerializeField]
    private Button _mainMenuButton;
    [SerializeField]
    private GameObject _mainMenuButtonObject;
    [SerializeField]
    private Button _pauseButton;
    [SerializeField]
    private Button _backButton;
    [SerializeField]
    private GameObject _backButtonObject;

    [SerializeField]
    private GameObject _playFabObject;
    [SerializeField]
    private GameObject _scoreTextObject;
    
    private ScoreHandler _scoreHandler;
    private FruitsInstantiator _fruitsInstantiator;
    private FruitCountDown _fruitCountDown;
    private int _score;

    public void Initialize(ScoreHandler scoreCounter, FruitsInstantiator fruitsInstantiator, FruitCountDown fruitCountDown)
    {
        Time.timeScale = GameInfo.GameSpeed;
        _scoreHandler = scoreCounter;
        _fruitsInstantiator = fruitsInstantiator;
        _fruitCountDown = fruitCountDown;
        _scoreHandler.OnScoreChanged += ChangeScore;
        _scoreHandler.OnNewThousandScore += ShakeScore;
        ChangeScore(_scoreHandler.Score);
        _fruitsInstantiator.OnNextFruitGot += ShowNextFruit;
        ShowNextFruit(_fruitsInstantiator.NextFruit);
        _fruitCountDown.OnCountFinished += ShowGameOver;
        _restartButton.onClick.AddListener(Restart);
        _mainMenuButton.onClick.AddListener(ShowMainMenu);
        _pauseButton.onClick.AddListener(ShowPauseMenu);
        _backButton.onClick.AddListener(ProceedGame);
    }

    private void ChangeScore(int score)
    {
        _score = score;
    }

    private void ShakeScore()
    {
        _scoreTextObject.transform.DOShakeScale(1, 0.5f);
    }

    private void ShowNextFruit(FruitsConfig config)
    {
        _nextFruitImage.sprite = config.Sprite;
    }

    private void ShowGameOver()
    {
        _playFabObject.gameObject.SetActive(true);
        _gameOverObject.SetActive(true);
        _mainMenuButtonObject.SetActive(true);
        _restartButtonObject.SetActive(true);
        Time.timeScale = 0;
        OnGameOverShowd?.Invoke();
    }

    private void ShowPauseMenu()
    {
        _mainMenuButtonObject.SetActive(true);
        _restartButtonObject.SetActive(true);
        _backButtonObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void ProceedGame()
    {
        Time.timeScale = GameInfo.GameSpeed;
        _mainMenuButtonObject.SetActive(false);
        _restartButtonObject.SetActive(false);
        _backButtonObject.SetActive(false);
    }
    
    private void Restart()
    {
        SceneManager.LoadSceneAsync(3);
    }
    private void ShowMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    private void Update()
    {
        _scoreText.text = _score.ToString();
    }

    private void OnDestroy() 
    {
        _scoreHandler.OnScoreChanged -= ChangeScore;
        _fruitsInstantiator.OnNextFruitGot -= ShowNextFruit;
        _fruitCountDown.OnCountFinished -= ShowGameOver;
        _restartButton.onClick.RemoveListener(Restart);
        _mainMenuButton.onClick.RemoveListener(ShowMainMenu);
        _pauseButton.onClick.RemoveListener(ShowPauseMenu);
        _backButton.onClick.RemoveListener(ProceedGame);
    }
}
