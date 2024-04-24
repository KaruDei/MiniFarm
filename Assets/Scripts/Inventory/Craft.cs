using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Slot> _items;

    public List<SlotUI> craftSlots;

    private void FixedUpdate()
    {
        if (craftSlots[0].slot != null && craftSlots[1].slot != null && craftSlots[0].slot.item != null && craftSlots[1].slot.item != null)
        {
            if ((craftSlots[0].slot.item.itemName == "Eggplant" && craftSlots[1].slot.item.itemName == "Pampkin") || (craftSlots[0].slot.item.itemName == "Pampkin" && craftSlots[1].slot.item.itemName == "Eggplant"))
            {
                craftSlots[2].SetItem(_items[4]);
            }
            else if ((craftSlots[0].slot.item.itemName == "Beet" && craftSlots[1].slot.item.itemName == "Carrot") || (craftSlots[0].slot.item.itemName == "Carrot" && craftSlots[1].slot.item.itemName == "Beet"))
            {
                craftSlots[2].SetItem(_items[5]);
            }
            else if ((craftSlots[0].slot.item.itemName == "Eggplant" && craftSlots[1].slot.item.itemName == "Carrot") || (craftSlots[0].slot.item.itemName == "Carrot" && craftSlots[1].slot.item.itemName == "Eggplant"))
            {
                craftSlots[2].SetItem(_items[6]);
            }
            else
            {
                craftSlots[2].SetEmpty();
            }
        }
        else if (craftSlots[0].slot != null && craftSlots[0].slot.item != null && (craftSlots[1].slot == null || craftSlots[1].slot.item == null))
        {
            if (craftSlots[0].slot.item.itemName == "Carrot")
            {
                craftSlots[2].SetItem(_items[0]);
            }
            else if (craftSlots[0].slot.item.itemName == "Beet")
            {
                craftSlots[2].SetItem(_items[1]);
            }
            else if (craftSlots[0].slot.item.itemName == "Eggplant")
            {
                craftSlots[2].SetItem(_items[2]);
            }
            else if (craftSlots[0].slot.item.itemName == "Pampkin")
            {
                craftSlots[2].SetItem(_items[3]);
            }
            else
            {
                craftSlots[2].SetEmpty();
            }
        }
        else if (craftSlots[1].slot != null && craftSlots[1].slot.item != null && (craftSlots[0].slot == null || craftSlots[0].slot.item == null))
        {
            if (craftSlots[1].slot.item.itemName == "Carrot")
            {
                craftSlots[2].SetItem(_items[0]);
            }
            else if (craftSlots[1].slot.item.itemName == "Beet")
            {
                craftSlots[2].SetItem(_items[1]);
            }
            else if (craftSlots[1].slot.item.itemName == "Eggplant")
            {
                craftSlots[2].SetItem(_items[2]);
            }
            else if (craftSlots[1].slot.item.itemName == "Pampkin")
            {
                craftSlots[2].SetItem(_items[3]);
            }
            else
            {
                craftSlots[2].SetEmpty();
            }
        }
        else
        {
            craftSlots[2].SetEmpty();
        }
        
    }

    public void CraftItem()
    {
        _player.Inventory.AddItem(craftSlots[2].slot.item, craftSlots[2].slot.count);
        if (craftSlots[0].slot != null && craftSlots[1].slot != null && craftSlots[0].slot.item != null && craftSlots[1].slot.item != null)
        {
            _player.Inventory.RemoveItem(craftSlots[0].slot.item);
            _player.Inventory.RemoveItem(craftSlots[1].slot.item);
            SetEmpty();
        }
        else if (craftSlots[0].slot != null && craftSlots[0].slot.item != null && (craftSlots[1].slot == null || craftSlots[1].slot.item == null))
        {
            _player.Inventory.RemoveItem(craftSlots[0].slot.item);
            SetEmpty();
        }
        else if (craftSlots[1].slot != null && craftSlots[1].slot.item != null && (craftSlots[0].slot == null || craftSlots[0].slot.item == null))
        {
            _player.Inventory.RemoveItem(craftSlots[1].slot.item);
            SetEmpty();
        }

        _player.Inventory.InventoryUI.Setup();
    }

    public void SetEmpty()
    {
        craftSlots[0].SetEmpty();
        craftSlots[1].SetEmpty();
        craftSlots[2].SetEmpty();
    }
}
