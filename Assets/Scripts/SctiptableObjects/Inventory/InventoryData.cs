using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс хранения информации о инвентаре
/// </summary>
[CreateAssetMenu(fileName = "InventoryData", menuName = "Farm/Data/Inventory", order = 0)]
public class InventoryData : ScriptableObject
{
    public string InventoryName;
    public int maxSlots;

    public List<Slot> slots = new();

    [Header("StartItems")]
    public List<Item> startItems;
    public List<int> startItemsCount;

    public void Save()
    {
        PlayerPrefs.SetString(InventoryName, JsonUtility.ToJson(this));
    }

    public bool Load()
    {
        slots.Clear();
        if (PlayerPrefs.HasKey(InventoryName))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(InventoryName), this);
            return true;
        }
        return false;
    }

    public void Clear()
    {
        slots.Clear();
    }
}
