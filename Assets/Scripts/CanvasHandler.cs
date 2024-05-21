using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private Image _nextFruitImage;

    private ScoreCounter _scoreCounter;
    private FruitsInstantiator _fruitsInstantiator;
    private int _score;

    private FruitsConfig _config;


    public void Initialize(ScoreCounter scoreCounter, FruitsInstantiator fruitsInstantiator)
    {
        _scoreCounter = scoreCounter;
        _scoreCounter.OnScoreChanged += ChangeScore;
        _fruitsInstantiator = fruitsInstantiator;
        _fruitsInstantiator.OnNextFruitGot += ShowNextFruit;
        Debug.Log("init");
    }

    private void ChangeScore(int score)
    {
        _score = score;
    }

    private void ShowNextFruit(FruitsConfig config)
    {
        _config = config;
        _nextFruitImage.sprite = config.FruitPrefab.GetComponent<SpriteRenderer>().sprite;
    }
    private void Update()
    {
        _scoreText.text = _score.ToString();
    }

    private void OnDestroy() 
    {
        _scoreCounter.OnScoreChanged -= ChangeScore;
        _fruitsInstantiator.OnNextFruitGot -= ShowNextFruit;
    }
}
