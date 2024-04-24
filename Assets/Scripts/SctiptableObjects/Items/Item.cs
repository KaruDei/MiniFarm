using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Farm/Items/item", order = 0)]
/// <summary>
/// Класс хранящий информацию о предмете
/// </summary>
public class Item : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public Sprite sprite;

    public bool canStack;
    public int maxStackCount;
    public int level;

    [Header("Buy")]
    public bool canBuy;
    public int buyPrice;
    public ShopCategory shopCategory;

    [Header("Sell")]
    public bool canSell;
    public int sellPrice;

    private void OnValidate()
    {
        if (!canStack || maxStackCount < 0)
        {
            maxStackCount = 1;
        }

        if (!canBuy)
        {
            buyPrice = 0;
            shopCategory = ShopCategory.NONE;
        }

        if (!canSell)
        {
            sellPrice = 0;
        }
    }
}

public enum ShopCategory
{
    NONE,
    SEED,
    TOOL,
}