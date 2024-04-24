using UnityEngine;

/// <summary>
/// Класс реализующий функционал магазина
/// </summary>

public class Shop : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Animator _badBuyFieldAnimator;
    [SerializeField] private InventoryData _shopInventory;
    public InventoryData ShopInventory => _shopInventory;

    public bool BuyItem(Item item)
    {
        if (item != null)
        {
            if (_player.PlayerData.money - item.buyPrice >= 0)
            {
                _player.Inventory.AddItem(item);
                _player.RemoveMoney(item.buyPrice);
                return true;
            }
            else {
                _badBuyFieldAnimator.SetTrigger("Play");
            }
        }
        return false;
    }
}
