using System;
using UnityEngine;

public class ScoreHandler 
{
    private FruitsInstantiator _fruitInstantiator;
    private GameCanvas _gameCanvas;
    public int Score { get; private set; }
    public int BestScore { get; private set; }

    public event Action<int> OnScoreChanged;
    public ScoreHandler(FruitsInstantiator fruitsInstantiator, GameCanvas gameCanvas)
    {
        _fruitInstantiator = fruitsInstantiator;
        _gameCanvas = gameCanvas;
        _fruitInstantiator.OnFruitInstantiated += AddScore;
        _gameCanvas.OnGameOverShowd += SaveScore;
    }

    private void SaveScore()
    {
        if (Score > PlayerPrefs.GetInt("BestScore"))
        {
            BestScore = Score;
            PlayerPrefs.SetInt("BestScore", BestScore);
        }
    }

    private void AddScore(Fruit fruit)
    {
        Score = Score + fruit.FruitsConfig.Score;
        OnScoreChanged.Invoke(Score);
    }

    public void Update()
    {
 
    }
}
