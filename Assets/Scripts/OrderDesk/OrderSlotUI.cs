using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Класс отображаемого слота инвентаря
/// </summary>

public class OrderSlotUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform _itemsField;
    [SerializeField] private GameObject _itemPrefab;

    private OrderDeskUI _orderDeskUI;

    public OrderSlot orderSlot;

    private void Start()
    {
        _orderDeskUI = transform.parent.parent.parent.GetComponent<OrderDeskUI>();
    }

    public void SetOrderItem(OrderSlot orderSlot)
    {
        this.orderSlot = orderSlot;

        foreach (var orderItem in orderSlot.items)
        {
            GameObject item = Instantiate(_itemPrefab, _itemsField);
            item.GetComponent<Image>().sprite = orderItem.Key.sprite;
            item.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = orderItem.Value.ToString();
        }
    }

    public void DestroyOrder()
    {
        int index = transform.GetSiblingIndex();

        if (_orderDeskUI.CheckCompleteOrder(index))
            Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DestroyOrder();
    }
}
