/// <summary>
/// Класс слота инвентаря
/// </summary>
[System.Serializable]
public class Slot
{
    public Item item;
    public int count;

    /// <summary>
    /// Класс конструктор слота инвентаря
    /// </summary>
    public Slot()
    {
        item = null;
        count = 0;
    }

    public bool CanAddItem()
    {
        if (item.canStack && count < item.maxStackCount)
        {
            return true;
        }
        return false;
    }

    public void AddItem(Item item, int count = 1)
    {
        this.item = item;
        if (item is ToolItem toolItem)
        {
            this.count = toolItem.useCount;
        }
        else
            this.count += count;
    }
}
