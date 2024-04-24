using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Класс отображаемого слота
/// </summary>
public class SlotUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Sprite _emptySprite;

    public Slot slot;

    public void SetEmpty()
    {
        _icon.sprite = _emptySprite;
        _text.text = "";
        slot = null;
    }
    public void SetItem(Slot slot)
    {
        if (slot.item == null) return;

        _icon.sprite = slot.item.sprite;
        if (slot.item is ToolItem)
        {
            _text.text = slot.count.ToString();
        }
        else
        {
            _text.text = $"x{slot.count}";
        }
        this.slot = slot;
    }

    public void SetShopItem(Slot slot)
    {
        if (slot.item == null) return;

        if (slot.item is SeedItem seedItem)
        {
            _icon.sprite = seedItem.product.sprite;
        }
        else
        {
            _icon.sprite = slot.item.sprite;
        }
        _text.text = $"{slot.item.buyPrice}";
        this.slot = slot;
    }
}
