using TMPro;
using UnityEngine;

public class CanvasHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    private ScoreCounter _scoreCounter;
    private int _score;
    
    public void Initialize(ScoreCounter scoreCounter)
    {
        _scoreCounter = scoreCounter;
        _scoreCounter.OnScoreChanged += ChangeScore;
    }
    private void ChangeScore(int score)
    {
        _score = score;
    }

    private void Update()
    {
        _scoreText.text = _score.ToString();
    }

    private void OnDestroy() 
    {
        _scoreCounter.OnScoreChanged -= ChangeScore;
    }
}
