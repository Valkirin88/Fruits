using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FruitBlinker : MonoBehaviour 
{
    private FruitCountDown _fruitCountDown;
    private List<Fruit> _fruits;
    private Sequence _sequence;
    public void Initialize(FruitCountDown fruitCountDown)
    {
        _fruitCountDown = fruitCountDown;
        _fruitCountDown.OnFruitsInDanger += UpdateFruits;
        _sequence = DOTween.Sequence();
    }

    private void UpdateFruits(List<Fruit> fruits)
    {
        _fruits = fruits;
        Blink();
    }

    private void Blink()
    {
        //foreach(Fruit fruit in _fruits)
        //{
        //    fruit.gameObject.GetComponent<SpriteRenderer>().DOFade(1, 1).Flip();
        //}
    }

    public void OnDestroy()
    {
        _fruitCountDown.OnFruitsInDanger -= UpdateFruits;
    }

    private void Update()
    {
        foreach (Fruit fruit in _fruits)
        {
            fruit.gameObject.GetComponent<SpriteRenderer>().DOFade(1, 1).Flip();
        }
    }
}
