using System.Collections.Generic;
using DG.Tweening;

public class FruitBlinker 
{
    private FruitsContainer _fruitContainer;
    private List<Fruit> _fruits;
    public FruitBlinker(FruitsContainer fruitsContainer)
    {
        _fruitContainer = fruitsContainer;
    }

    public void Update()
    {
        Blink();
    }
    private void Blink()
    {
        _fruits = _fruitContainer.Fruits;
        if(_fruits.Count > 0 ) 
        {
            foreach (Fruit fruit in _fruits)
            {
                if (fruit.IsInDanger && !fruit.IsBlinking)
                {
                    fruit.IsBlinking = true;
                    fruit.SpriteRenderer.DOFade(0, 0.3f).SetLoops(-1, LoopType.Yoyo);
                }
                else if (!fruit.IsInDanger && fruit.IsBlinking)
                {
                    fruit.IsBlinking = false;
                    fruit.SpriteRenderer.DOKill();
                    fruit.SpriteRenderer.DOFade(1, 0.3f);
                }
            }
        }
    }
}
