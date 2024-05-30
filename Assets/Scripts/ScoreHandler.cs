using System;
using UnityEngine;

public class ScoreHandler 
{
    private FruitsInstantiator _fruitInstantiator;
    public int Score { get; private set; }
    public int BestScore { get; private set; }

    public event Action<int> OnScoreChanged;
    public ScoreHandler(FruitsInstantiator fruitsInstantiator)
    {
        _fruitInstantiator = fruitsInstantiator;
        _fruitInstantiator.OnFruitInstantiated += AddScore;
    }

    private void AddScore(Fruit fruit)
    {
        Score = Score + fruit.FruitsConfig.Score;
        OnScoreChanged.Invoke(Score);
    }

    public void Update()
    {
        if(Score > BestScore) 
        {
            BestScore = Score;
            PlayerPrefs.SetInt("BestScore", BestScore);
        }
    }
}
