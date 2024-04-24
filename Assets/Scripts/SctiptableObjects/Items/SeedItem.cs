using UnityEngine;

[CreateAssetMenu(fileName = "Seed", menuName = "Farm/Items/Seed", order = 0)]
/// <summary>
/// Класс хранящий информацию о семени
/// </summary>
public class SeedItem : Item
{
    [Header("Seed")]
    public int growTime;
    public int growCount;
    public int exp;
    public Item product;
    public Sprite growSprite;
    public Sprite LoseSprite;
}
