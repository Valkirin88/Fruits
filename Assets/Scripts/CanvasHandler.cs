using TMPro;
using Unity.VisualScripting.FullSerializer;
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
    
    public void Initialize(ScoreCounter scoreCounter, FruitsInstantiator fruitsInstantiator)
    {
        _scoreCounter = scoreCounter;
        _scoreCounter.OnScoreChanged += ChangeScore;
        _fruitsInstantiator = fruitsInstantiator;
        _fruitsInstantiator.OnNextFruitShown += ShowNextFruit;
    }

    private void ChangeScore(int score)
    {
        _score = score;
    }

    private void ShowNextFruit(FruitsConfig config)
    {
        //_nextFruitImage = config.FruitPrefab.GetComponent<SpriteRenderer>();
        Debug.Log(_nextFruitImage);
    }
    private void Update()
    {
        _scoreText.text = _score.ToString();
    }

    private void OnDestroy() 
    {
        _scoreCounter.OnScoreChanged -= ChangeScore;
        _fruitsInstantiator.OnNextFruitShown -= ShowNextFruit;
    }
}
