using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

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
        foreach (Fruit fruit in _fruits)
        {
            if (fruit.IsInDanger && !fruit.IsBlinking)
            {
                Debug.Log("blink");
                fruit.IsBlinking = true;
                var spriteRenderer = fruit.gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.DOFade(0, 0.3f).SetLoops(-1, LoopType.Yoyo);
            }
            else if(!fruit.IsInDanger && fruit.IsBlinking)
            {
                fruit.IsBlinking = false;
                var spriteRenderer = fruit.gameObject.GetComponent<SpriteRenderer>();
                spriteRenderer.DOKill();
                spriteRenderer.DOFade(1, 0.3f);
            }
        }
    }
}
