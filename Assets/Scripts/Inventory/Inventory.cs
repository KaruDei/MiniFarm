using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс реализующий функционал инвентаря
/// </summary>
public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryData _inventoryData;
    [SerializeField] private Player _player;
    [SerializeField] private InventoryUI _inventoryUI;
    public InventoryData InventoryData => _inventoryData;
    public Player Player => _player;
    public InventoryUI InventoryUI => _inventoryUI;

    public bool AddItem(Item item, int count = 1)
    {
        if (item != null && count > 0)
        {
            for (int i = 0; i < InventoryData.slots.Count; i++)
            {
                if (InventoryData.slots[i].item == item && InventoryData.slots[i].CanAddItem())
                {
                    InventoryData.slots[i].AddItem(item, count);
                    return true;
                }
            }

            for (int i = 0; i < InventoryData.slots.Count; i++)
            {
                if (InventoryData.slots[i].item == null)
                {
                    InventoryData.slots[i].AddItem(item, count);
                    return true;
                }
            }
        }
        return false;
    }

    public bool RemoveItem(Item item, int count = 1)
    {
        if (item != null && count > 0)
        {
            for (int i = 0; i < InventoryData.slots.Count; i++)
            {
                if (InventoryData.slots[i].item == item && InventoryData.slots[i].count - count > 0)
                {
                    InventoryData.slots[i].count -= count;
                    return true;
                }
                else if (InventoryData.slots[i].item == item && InventoryData.slots[i].count - count == 0)
                {
                    InventoryData.slots[i].item = null;
                    InventoryData.slots[i].count = 0;
                    return true;
                }
                else if ((InventoryData.slots[i].item == item && InventoryData.slots[i].count - count < 0 && CheckCanRemove(item, count)) || item is ToolItem)
                {
                    Item currentItem = InventoryData.slots[i].item;
                    int currentCount = count - InventoryData.slots[i].count;

                    InventoryData.slots[i].item = null;
                    InventoryData.slots[i].count = 0;

                    RemoveItem(currentItem, currentCount);
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckCanRemove(Item item, int count = 1)
    {
        int countItems = 0;

        if (item != null && count > 0)
        {
            for (int i = 0; i < InventoryData.slots.Count; i++)
            {
                if (InventoryData.slots[i].item == item)
                {
                    countItems += InventoryData.slots[i].count;
                }
            }
        }

        if(countItems >= count)
            return true;
        else
            return false;
    }
}
