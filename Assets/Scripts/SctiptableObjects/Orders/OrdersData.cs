using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Класс хранения информации о заказах
/// </summary>
[CreateAssetMenu(fileName = "OrdersData", menuName = "Farm/Data/Orders", order = 0)]
public class OrdersData : ScriptableObject
{
    public int maxOrdersSlots = 4;
    public List<Item> cultures;
    public List<OrderSlot> orders = new();

    public void Save()
    {
        PlayerPrefs.SetString("OrdersData", JsonUtility.ToJson(this));
        Debug.Log(PlayerPrefs.GetString("OrdersData"));
    }

    public bool Load()
    {
        if (PlayerPrefs.HasKey("OrdersData"))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("OrdersData"), this);
            Debug.Log(PlayerPrefs.GetString("OrdersData"));
            return true;
        }
        return false;
    }

    public void Clear()
    {
        orders.Clear();
    }
}
