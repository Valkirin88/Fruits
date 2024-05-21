using System;

public class ScoreCounter 
{
    private FruitsInstantiator _fruitInstantiator;
    public int Score { get; private set; }

    public event Action<int> OnScoreChanged;
    public ScoreCounter(FruitsInstantiator fruitsInstantiator)
    {
        _fruitInstantiator = fruitsInstantiator;
        _fruitInstantiator.OnFruitInstantiated += AddScore;
    }

    private void AddScore(Fruit fruit)
    {
        Score = Score + fruit.FruitsConfig.Score;
        OnScoreChanged.Invoke(Score);
    }
}
