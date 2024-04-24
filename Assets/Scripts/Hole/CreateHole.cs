using UnityEngine;

public class CreateHole : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _actionButton;
    [SerializeField] private GameObject _holePrefab;
    [SerializeField] private Transform _holeField;

    private Renderer _holeRenderer;

    public GameObject currentHole;
    public bool canPlace = false;

    private void FixedUpdate()
    {
        if (_player != null && _player.Inventory != null)
        {
            if (_player.Inventory.InventoryData.slots[0].item != null && _player.Inventory.InventoryData.slots[0].item is ToolItem toolItem && toolItem.toolType == ToolType.SHOVEL)
            {
                if (currentHole == null)
                {
                    Vector3Int playerPosition = new Vector3Int(Mathf.RoundToInt(_player.transform.position.x), Mathf.RoundToInt(_player.transform.position.y), Mathf.RoundToInt(_player.transform.position.z));
                    currentHole = Instantiate(_holePrefab, playerPosition, Quaternion.Euler(0,0,0), _holeField);
                    currentHole.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
                    _holeRenderer = currentHole.GetComponent<Renderer>();
                    currentHole.tag = "Untagged";
                }
                else
                {
                    currentHole.transform.position = new Vector3Int(Mathf.RoundToInt(_player.transform.position.x), Mathf.RoundToInt(_player.transform.position.y), Mathf.RoundToInt(_player.transform.position.z));
                }

                if (IsHoleClear())
                {
                    _actionButton.SetActive(true);
                    _holeRenderer.material.color = Color.green;
                    canPlace = true;
                }
                else
                {
                    _actionButton.SetActive(false);
                    _holeRenderer.material.color = Color.red;
                    canPlace = false;
                }
            }
            else
            {
                DestroyCurrentHole();
                canPlace = false;
            }
        }
    }

    private void DestroyCurrentHole()
    {
        if (currentHole != null)
        {
            Destroy(currentHole);
            currentHole = null;
        }
    }

    private bool IsHoleClear()
    {
        RaycastHit2D[] colliders = Physics2D.BoxCastAll(currentHole.transform.position, currentHole.transform.localScale, 0.01f, Vector2.zero);
        foreach (var collider in colliders)
        {
            if (collider.collider.gameObject.tag == "Hole" || collider.collider.gameObject.tag == "Shop" || collider.collider.gameObject.tag == "OrderDesk" || collider.collider.gameObject.tag == "Map")
            {
                return false;
            }
        }
        return true;
    }

    public void CreateHoleClick()
    {
        if (currentHole != null)
        {
            if (_player.Inventory.InventoryData.slots[0].item is ToolItem toolItem && toolItem.toolType == ToolType.SHOVEL)
            {
                _player.Inventory.InventoryData.slots[0].count--;
                if (_player.Inventory.InventoryData.slots[0].count <= 0)
                {
                    _player.Inventory.RemoveItem(toolItem);
                    _actionButton.SetActive(false);
                }
                Instantiate(_holePrefab, currentHole.transform.position, Quaternion.Euler(0,0,0), _holeField);
            }
        }
    }
}
