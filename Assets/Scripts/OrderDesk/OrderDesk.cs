using System.Collections.Generic;
using UnityEngine;

public class OrderDesk : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private OrdersData _orderData;
    public OrdersData OrderData => _orderData;

    private void FixedUpdate()
    {
        if (_orderData.orders.Count < _orderData.maxOrdersSlots)
        {
            for (int i = _orderData.orders.Count; i < _orderData.maxOrdersSlots; i++)
            {
                CreateOrder();
            }
        }
    }

    private void CreateOrder()
    {
        List<Item> levelItems = LevelItems(_orderData.cultures);
        List<Item> usedItems = new List<Item>();
        Dictionary<Item, int> items = new Dictionary<Item, int>();
        int money;
        int exp = Random.Range(0, 150);

        int slotsCount = Random.Range(1, 6);
        if (slotsCount > levelItems.Count)
        {
            slotsCount = levelItems.Count;
        }

        for (int i = 0; i < slotsCount; i++)
        {
            int productCount = Random.Range(5, 15);
            Item item = null;
            
            do
            {
                int index = Random.Range(0, levelItems.Count);
                item = levelItems[index];
            } while (!CanAddItem(usedItems, item));

            usedItems.Add(item);
            items.Add(item, productCount);
        }

        money = SetMoney(items);

        if (money - 500 < 0)
        {
            money = Random.Range(0, money + 500);
        }
        else
        {
            money = Random.Range(money - 500, money + 500);
        }

        _orderData.orders.Add(new OrderSlot(items, money, exp));
    }

    private List<Item> LevelItems(List<Item> cultures)
    {
        List<Item> items = new List<Item>();
        foreach (Item item in cultures)
        {
            if (item.level <= _player.PlayerData.level)
            {
                items.Add(item);
            }
        }
        return items;
    }

    private bool CanAddItem(List<Item> usedItems, Item newItem)
    {
        return !usedItems.Contains(newItem);
    }

    private int SetMoney(Dictionary<Item, int> items)
    {
        int money = 0;

        foreach (var item in items)
        {
            money += item.Key.sellPrice * item.Value;
        }

        return money;
    }
}
