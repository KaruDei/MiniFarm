using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс передвижения предметов по инвентарю
/// </summary>

public class SelectItems : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventoryUI _inventoryUI;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _selectedSprite;
    [SerializeField] private Craft _craft;

    private int _selectedIndex = 0;
    private Slot _tempSlot = new();

    public bool selected = false;

    public void SelectItem(int inventoryIndex)
    {
        if (!selected && _inventoryUI.slotsUI[inventoryIndex].slot != null && _inventoryUI.slotsUI[inventoryIndex].slot.item != null)
        {
            _inventoryUI.slotsUI[inventoryIndex].GetComponent<Image>().sprite = _selectedSprite;
            _selectedIndex = inventoryIndex;
            selected = true;
        }
        else if (selected && inventoryIndex != _selectedIndex)
        {
            _inventoryUI.slotsUI[_selectedIndex].GetComponent<Image>().sprite = _defaultSprite;
            _tempSlot = _inventory.InventoryData.slots[inventoryIndex];
            _inventory.InventoryData.slots[inventoryIndex] = _inventory.InventoryData.slots[_selectedIndex];
            _inventory.InventoryData.slots[_selectedIndex] = _tempSlot;
            selected = false;
            _inventoryUI.Setup();   
        }
        else if (selected && inventoryIndex == _selectedIndex)
        {
            _inventoryUI.slotsUI[inventoryIndex].GetComponent<Image>().sprite = _defaultSprite;
            selected = false;
        }
    }

    public void SelectCraftItem(int craftIndex)
    {
        if (craftIndex == 0 || craftIndex == 1)
        {
            Debug.Log(_craft.craftSlots);
            Debug.Log(_inventory.InventoryData.slots[_selectedIndex]);
            _craft.craftSlots[craftIndex].SetItem(_inventory.InventoryData.slots[_selectedIndex]);
            _inventoryUI.slotsUI[_selectedIndex].GetComponent<Image>().sprite = _defaultSprite;
            selected = false;
        }
    }

    public void CraftItem()
    {
        _craft.CraftItem();
    }
}
