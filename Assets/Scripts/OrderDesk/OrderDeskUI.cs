using System.Collections.Generic;
using UnityEngine;

public class OrderDeskUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private OrderDesk _orderDesk;
    [SerializeField] private Transform _ordersField;
    [SerializeField] private GameObject _orderPrefab;

    public List<OrderSlotUI> orderSlotsUI;

    private void FixedUpdate()
    {
        if (orderSlotsUI.Count < _orderDesk.OrderData.orders.Count)
        {
            for (int i = orderSlotsUI.Count; i < _orderDesk.OrderData.orders.Count; i++)
            {
                GameObject order = Instantiate(_orderPrefab, _ordersField);
                order.GetComponent<OrderSlotUI>().SetOrderItem(_orderDesk.OrderData.orders[i]);
                orderSlotsUI.Add(order.GetComponent<OrderSlotUI>());
            }
        }  
    }

    public bool DestroyOrder(int index)
    {
        if (orderSlotsUI.Count > index && _orderDesk.OrderData.orders.Count > index)
        {
            _player.AddExp(orderSlotsUI[index].orderSlot.exp);
            _player.AddMoney(orderSlotsUI[index].orderSlot.money);

            _orderDesk.OrderData.orders.RemoveAt(index);
            orderSlotsUI.RemoveAt(index);
            return true;
        }
        else
            return false;
    }

    public void DestroyAllOrders()
    {
        if (orderSlotsUI.Count == _orderDesk.OrderData.orders.Count)
        {
            _orderDesk.OrderData.orders.Clear();
            orderSlotsUI.Clear();
            for (int i = 0; i < _ordersField.childCount; i++)
            {
                Destroy(_ordersField.GetChild(i).gameObject);
            }
        }
    }

    public bool CheckCompleteOrder(int index)
    {
        if (index < 0 || index >= _orderDesk.OrderData.orders.Count)
        {
            Debug.LogError("Invalid order index");
            return false;
        }

        foreach (KeyValuePair<Item, int> kvp in _orderDesk.OrderData.orders[index].items)
        {
            Item item = kvp.Key;
            int requiredCount = kvp.Value;

            int satisfiedCount = 0;

            for (int i = 0; i < _player.Inventory.InventoryData.slots.Count; i++)
            {
                if (_player.Inventory.InventoryData.slots[i].item == item)
                {
                    int itemsToTake = Mathf.Min(requiredCount - satisfiedCount, _player.Inventory.InventoryData.slots[i].count);

                    //inventorySlot.count -= itemsToTake;

                    satisfiedCount += itemsToTake;
                }

                if (satisfiedCount == requiredCount)
                {
                    break;
                }
            }

            if (satisfiedCount != requiredCount)
            {
                return false;
            }
        }

        CompleteOrder(index);
        return true;
    }

    public void CompleteOrder(int index)
    {
        foreach (KeyValuePair<Item, int> kvp in _orderDesk.OrderData.orders[index].items)
        {
            Item item = kvp.Key;
            int requiredCount = kvp.Value;

            int satisfiedCount = 0;

            for (int i = 0; i < _player.Inventory.InventoryData.slots.Count; i++)
            {
                if (_player.Inventory.InventoryData.slots[i].item == item)
                {
                    int itemsToTake = Mathf.Min(requiredCount - satisfiedCount, _player.Inventory.InventoryData.slots[i].count);

                    _player.Inventory.RemoveItem(_player.Inventory.InventoryData.slots[i].item, itemsToTake);

                    satisfiedCount += itemsToTake;
                }

                if (satisfiedCount == requiredCount)
                {
                    break;
                }
            }

        }

        // Удаляем выполненный заказ из списка заказов
        DestroyOrder(index);
    }
}
