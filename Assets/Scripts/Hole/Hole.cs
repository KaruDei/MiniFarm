using System.Collections;
using UnityEngine;

/// <summary>
/// Класс реализующий функционал грядки
/// </summary>

public class Hole : MonoBehaviour
{
    [Header("SpriteRenderers")]
    [SerializeField] private SpriteRenderer _holeSpriteRenderer;
    [SerializeField] private SpriteRenderer _plantSpriteRenderer;
    [Header("Sprite")]
    [SerializeField] private Sprite _dirtSprite;
    [SerializeField] private Sprite _selectedSprite;
    [SerializeField] private Sprite _defaultSprite;
    [Header("Objects")]
    [SerializeField] private GameObject _weed;

    [Header("Debuging")]
    public HoleStates state = HoleStates.EMPTY;
    public SeedItem item = null;

    public bool isGrow = false;
    public bool isWeed = false;

    public void IsSelected()
    {
        _holeSpriteRenderer.sprite = _selectedSprite;
    }

    public void IsNotSelected()
    {
        _holeSpriteRenderer.sprite = _defaultSprite;
    }

    public void Action(Player player)
    {
        if (state == HoleStates.EMPTY)
        {
            if (item == null && player.Inventory.InventoryData.slots[0].item != null && player.Inventory.InventoryData.slots[0].item is SeedItem seedItem)
            {
                item = seedItem;
                if (player.Inventory.RemoveItem(player.Inventory.InventoryData.slots[0].item))
                {
                    StartCoroutine(Grow(item));
                }
            }
            return;
        }

        if (state == HoleStates.READY)
        {
            player.Inventory.AddItem(item.product, item.growCount);
            player.AddExp(item.exp);
            state = HoleStates.PLOW;
            _plantSpriteRenderer.sprite = _dirtSprite;
            return;
        }

        if (state == HoleStates.PLOW && player.Inventory.InventoryData.slots[0].item != null)
        {
            if (player.Inventory.InventoryData.slots[0].item is ToolItem toolItem && toolItem.toolType == ToolType.HOE)
            {
                state = HoleStates.EMPTY;
                item = null;
                _plantSpriteRenderer.sprite = null;
                player.Inventory.InventoryData.slots[0].count--;
                if (player.Inventory.InventoryData.slots[0].count <= 0)
                    player.Inventory.RemoveItem(toolItem);
                return;
            }
        }

        if (state == HoleStates.LOSE)
        {
            state = HoleStates.PLOW;
            _plantSpriteRenderer.sprite = _dirtSprite;
            return;
        }

        if (isWeed)
        {
            _weed.SetActive(false);
            isWeed = false;
            return;
        }
    }

    public IEnumerator Grow(SeedItem seedItem)
    {
        state = HoleStates.GROW;
        _holeSpriteRenderer.sprite = _defaultSprite;
        _plantSpriteRenderer.sprite = seedItem.sprite;
        isGrow = true;

        int time = seedItem.growTime;
        int lose = 0;

        while (isGrow)
        {
            if (!isWeed && time - 20 > 0)
            {
                time -= 20;
                yield return new WaitForSeconds(20);
                isWeed = true;
                _weed.SetActive(true);
                lose = 0;
            }
            else if (!isWeed && time - 20 <= 0)
            {
                isGrow = false;
            }

            while (isWeed)
            {
                if (lose < 20)
                {
                    lose++;
                }
                else
                {
                    time = 0;
                    isWeed = false;
                    isGrow = false;
                    state = HoleStates.LOSE;
                }
                yield return new WaitForSeconds(1);
            }

            yield return new WaitForSeconds(1);
        }

        if (state != HoleStates.LOSE)
        {
            yield return new WaitForSeconds(time);
            state = HoleStates.READY;
            _plantSpriteRenderer.sprite = seedItem.growSprite;
        }
        else if (state == HoleStates.LOSE)
        {
            _weed.SetActive(false);
            _plantSpriteRenderer.sprite = seedItem.LoseSprite;
        }
    }
}

public enum HoleStates
{
    EMPTY,
    GROW,
    READY,
    PLOW,
    LOSE,
}
