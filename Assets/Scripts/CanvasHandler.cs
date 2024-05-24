using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private Image _nextFruitImage;
    [SerializeField]
    private GameObject _gameOverObject;
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private GameObject _restartButtonObject;

    private ScoreCounter _scoreCounter;
    private FruitsInstantiator _fruitsInstantiator;
    private GameOverZone _lostZone;
    private int _score;

    public void Initialize(ScoreCounter scoreCounter, FruitsInstantiator fruitsInstantiator, GameOverZone lostZone)
    {
        _scoreCounter = scoreCounter;
        _fruitsInstantiator = fruitsInstantiator;
        _lostZone = lostZone;
        _scoreCounter.OnScoreChanged += ChangeScore;        
        _fruitsInstantiator.OnNextFruitGot += ShowNextFruit;
        _lostZone.OnGameOver += ShowGameOver;
        _restartButton.onClick.AddListener(Restart);
    }

    private void ChangeScore(int score)
    {
        _score = score;
    }

    private void ShowNextFruit(FruitsConfig config)
    {
        _nextFruitImage.sprite = config.FruitPrefab.GetComponent<SpriteRenderer>().sprite;
    }

    private void ShowGameOver()
    {
        _gameOverObject.SetActive(true);
        _restartButtonObject.SetActive(true);
        Time.timeScale = 0;
    }
    
    private void Restart()
    {
        //Time.timeScale = 1;       
        SceneManager.LoadSceneAsync(0);

    }

    private void Update()
    {
        Debug.Log(Time.timeScale);
        _scoreText.text = _score.ToString();
    }

    private void OnDestroy() 
    {
        _scoreCounter.OnScoreChanged -= ChangeScore;
        _fruitsInstantiator.OnNextFruitGot -= ShowNextFruit;
        _lostZone.OnGameOver -= ShowGameOver;
        _restartButton.onClick.RemoveListener(Restart);
    }
}
