using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    private FruitCountDown _fruitCountDown;
    public void Initialize(FruitCountDown fruitCountDown)
    {
        _fruitCountDown = fruitCountDown;
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Fruit>(out Fruit fruit))
        {
            if (fruit.IsFirstCollided   && !fruit.IsInMainZone)
            {
                fruit.IsInGameOverZone = true;
                _fruitCountDown.AddFruit(fruit);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Fruit>(out Fruit fruit))
        {
            if (fruit.IsFirstCollided)
            {
                fruit.IsInGameOverZone = false;
                _fruitCountDown.RemoveFruit(fruit);
            }
        }
    }
}
