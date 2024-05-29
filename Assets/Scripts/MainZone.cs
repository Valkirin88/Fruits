using UnityEngine;

public class MainZone : MonoBehaviour
{
    private FruitCountDown _fruitCountDown;
    public void Initialize(FruitCountDown fruitCountDown)
    {
        _fruitCountDown = fruitCountDown;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Fruit>(out Fruit fruit))
        {
            fruit.IsInMainZone = true;
            _fruitCountDown.RemoveFruit(fruit);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Fruit>(out Fruit fruit))
        {
            fruit.IsInMainZone = false;
        }
    }
}
