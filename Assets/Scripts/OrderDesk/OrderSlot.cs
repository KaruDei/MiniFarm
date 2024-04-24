using System.Collections.Generic;

/// <summary>
/// Класс хранящий информацию о заказе
/// </summary>
[System.Serializable]
public class OrderSlot
{
    public Dictionary<Item, int> items;
    public int money;
    public int exp;

    /// <summary>
    /// Конструктор класа OrderSlot
    /// </summary>
    /// <param name="items">Заказаные предметы</param>
    /// <param name="money">Денежная награда</param>
    /// <param name="exp">Количество опыта</param>
    public OrderSlot(Dictionary<Item, int> items, int money, int exp)
    {
        this.items = items;
        this.money = money;
        this.exp = exp;
    }
}
