using UnityEngine;

[CreateAssetMenu(fileName = "Tool", menuName = "Farm/Items/Tool", order = 0)]
/// <summary>
/// Класс хранения информации о иструменте
/// </summary>
public class ToolItem : Item
{
    [Header("Tool")]
    public int useCount;
    public ToolType toolType;

    private void OnValidate()
    {
        if (useCount <= 0)
        {
            useCount = 1;
        }
    }
}

public enum ToolType
{
    HOE,
    SHOVEL,
}
