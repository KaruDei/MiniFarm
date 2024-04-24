using UnityEngine;
/// <summary>
/// Класс реализующий функцию подбора предметов
/// </summary>
public class Collectable : MonoBehaviour
{
    [SerializeField] private Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().Inventory.AddItem(item);
            Destroy( gameObject );
        }   
    }
}
