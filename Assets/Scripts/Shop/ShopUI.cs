using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Класс отображения магазина
/// </summary>

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private Player _player;
    [SerializeField] private List<SlotUI> culturesSlots;
    [SerializeField] private List<SlotUI> toolsSlots;
    [SerializeField] private TextMeshProUGUI _moneyText;

    private int culturesCount = 0;
    private int toolsCount = 0;

    private void FixedUpdate()
    {
        _moneyText.text = $"Монет: {_player.PlayerData.money}";
    }

    public void Setup()
    {
        ClearShopSlots();
        if (culturesSlots.Count == 21 && toolsSlots.Count == 21 && _shop.ShopInventory.slots.Count > 0)
        {
            for (int i = 0; i < _shop.ShopInventory.slots.Count; i++)
            {
                if (_shop.ShopInventory.slots[i].item is ToolItem toolItem && toolItem.level <= _player.PlayerData.level)
                {
                    toolsSlots[toolsCount].SetShopItem(_shop.ShopInventory.slots[i]);
                    toolsCount++;
                }
                else if (_shop.ShopInventory.slots[i].item is SeedItem seedItem && seedItem.level <= _player.PlayerData.level)
                {
                    culturesSlots[culturesCount].SetShopItem(_shop.ShopInventory.slots[i]);
                    culturesCount++;
                }
            }
        }
        else
        {
            Debug.Log("Недостаточное количество слотов");
        }
    }

    public void ClearShopSlots()
    {
        for (int i = 0; i < culturesSlots.Count && i < toolsSlots.Count; i++)
        {
            culturesSlots[i].SetEmpty();
            toolsSlots[i].SetEmpty();
            toolsCount = 0;
            culturesCount = 0;
        }
    }
}
