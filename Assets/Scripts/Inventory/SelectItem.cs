using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Класс реализующий функцию выбора предмета
/// </summary>

public class SelectItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SelectItems _selectItems;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.GetComponent<SlotUI>() is SlotUI slotUI)
        {
            if (slotUI.name == "ActiveItem")
            {
                _selectItems.SelectItem(0);
                return;
            }
            else if (slotUI.tag == "CraftSlot")
            {
                if (slotUI.transform.GetSiblingIndex() == 2 && slotUI.slot.item != null)
                {
                    _selectItems.CraftItem();
                    return;
                }
                else if (_selectItems.selected)
                {
                    _selectItems.SelectCraftItem(slotUI.transform.GetSiblingIndex());
                    return;
                }
                else if (slotUI.slot.item != null)
                {
                    slotUI.SetEmpty();
                    return;
                }
            }
            else 
                _selectItems.SelectItem(slotUI.transform.GetSiblingIndex() + 1);
        }
    }
}
