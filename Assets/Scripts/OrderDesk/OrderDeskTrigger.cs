using UnityEngine;

/// <summary>
/// Класс реализующий функционал триггера доски заказов
/// </summary>

public class OrderDeskTrigger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _selectedSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _spriteRenderer.sprite = _selectedSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _spriteRenderer.sprite = _defaultSprite;
        }
    }
}
