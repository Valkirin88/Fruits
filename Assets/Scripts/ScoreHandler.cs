using System;
using UnityEngine;

public class ScoreHandler 
{
    public int Score { get; private set; }
    public int BestScore { get; private set; }

    public event Action<int> OnScoreChanged;
    public event Action OnNewThousandScore;

    private FruitsInstantiator _fruitInstantiator;
    private GameCanvas _gameCanvas;

    private int _pointsTillThousand =1000;

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
        AddPointsTillNewThousand();
    }

    private void AddPointsTillNewThousand()
    {
        if(Score >= _pointsTillThousand)
        {
            _pointsTillThousand = _pointsTillThousand + 1000;
            OnNewThousandScore?.Invoke();
        }
    }

    public void Update()
    {
        GameInfo.Score = Score;
    }
}
