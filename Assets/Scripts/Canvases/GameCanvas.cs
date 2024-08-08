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
    private TMP_Text _gameOverScoreText;


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


    //Objects
    [SerializeField]
    private GameObject _blueScreenMaskObject;
    [SerializeField]
    private GameObject _pauseHeaderObject;
    [SerializeField]
    private GameObject _playFabObject;
    [SerializeField]
    private GameObject _scoreTextObject;
    [SerializeField]
    private GameObject _backButtonObject;
    [SerializeField]
    private GameObject _pauseButtonObject;
    [SerializeField]
    private GameObject _nextFruitObject;

    private ScoreHandler _scoreHandler;
    private FruitsInstantiator _fruitsInstantiator;
    private FruitCountDown _fruitCountDown;
    private int _score;
    private float _textShakeTime = 2f;
    private float _textShakeStrength = 0.5f;

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
        _scoreTextObject.transform.DOShakeScale(_textShakeTime, _textShakeStrength);
    }

    private void ShowNextFruit(FruitsConfig config)
    {
        _nextFruitImage.sprite = config.Sprite;
        _nextFruitImage.transform.DOPunchScale(new Vector3(1, 1, 1), 0.8f, 1);
    }

    private void ShowGameOver()
    {
        _blueScreenMaskObject.gameObject.SetActive(true);
        _playFabObject.gameObject.SetActive(true);
        _gameOverObject.SetActive(true);
        _mainMenuButtonObject.SetActive(true);
        _restartButtonObject.SetActive(true);
        _pauseButtonObject.SetActive(false);
        _scoreTextObject.SetActive(false);
        _nextFruitObject.SetActive(false);
        _gameOverScoreText.text = _scoreText.text;
        Time.timeScale = 0;
        OnGameOverShowd?.Invoke();
    }

    private void ShowPauseMenu()
    {
        _blueScreenMaskObject.gameObject.SetActive(true);
        _pauseHeaderObject.gameObject.SetActive(true);
        _mainMenuButtonObject.SetActive(true);
        _restartButtonObject.SetActive(true);
        _backButtonObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void ProceedGame()
    {
        _blueScreenMaskObject.gameObject.SetActive(false);
        _pauseHeaderObject.gameObject.SetActive(false);
        Time.timeScale = GameInfo.GameSpeed;
        _mainMenuButtonObject.SetActive(false);
        _restartButtonObject.SetActive(false);
        _backButtonObject.SetActive(false);
    }
    
    private void Restart()
    {
        SceneManager.LoadSceneAsync(2);
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
