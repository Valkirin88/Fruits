using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    
    private ScoreHandler _scoreCounter;
    private FruitsInstantiator _fruitsInstantiator;
    private FruitCountDown _fruitCountDown;
    private int _score;

    public void Initialize(ScoreHandler scoreCounter, FruitsInstantiator fruitsInstantiator, FruitCountDown fruitCountDown)
    {
        _scoreCounter = scoreCounter;
        _fruitsInstantiator = fruitsInstantiator;
        _fruitCountDown = fruitCountDown;
        _scoreCounter.OnScoreChanged += ChangeScore;
        ChangeScore(_scoreCounter.Score);
        _fruitsInstantiator.OnNextFruitGot += ShowNextFruit;
        ShowNextFruit(_fruitsInstantiator.NextFruit);
        _fruitCountDown.OnCountFinished += ShowGameOver;
        _fruitCountDown.OnDanger += ShowDanger;
        _restartButton.onClick.AddListener(Restart);
        _mainMenuButton.onClick.AddListener(ShowMainMenu);
    }


    private void ShowDanger(bool f)
    {
        //_dangerTextObject.SetActive(f);
    }

    private void ChangeScore(int score)
    {
        _score = score;
    }

    private void ShowNextFruit(FruitsConfig config)
    {
        // _nextFruitImage.sprite = config.FruitPrefab.GetComponent<SpriteRenderer>().sprite;
        _nextFruitImage.sprite = config.Sprite;
    }

    private void ShowGameOver()
    {
        _gameOverObject.SetActive(true);
        _mainMenuButtonObject.SetActive(true);
        _restartButtonObject.SetActive(true);
        Time.timeScale = 0;
        OnGameOverShowd?.Invoke();
    }
    
    private void Restart()
    {
        Time.timeScale = 1;       
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
        _scoreCounter.OnScoreChanged -= ChangeScore;
        _fruitsInstantiator.OnNextFruitGot -= ShowNextFruit;
        _fruitCountDown.OnCountFinished -= ShowGameOver;
        _fruitCountDown.OnDanger -= ShowDanger;
        _restartButton.onClick.RemoveListener(Restart);
        _mainMenuButton.onClick.RemoveListener(ShowMainMenu);
    }
}
