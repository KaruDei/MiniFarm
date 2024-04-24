using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private OrderDesk _orderDesk;

    private void Start()
    {
        Load();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("PlayerData") && PlayerPrefs.HasKey(_inventory.InventoryData.InventoryName) && PlayerPrefs.HasKey("OrdersData"))
        {
            _player.PlayerData.Load();
            _inventory.InventoryData.Load();
            _orderDesk.OrderData.Load();
        }
        else
        {
            _player.PlayerData.Clear();
            _orderDesk.OrderData.Clear();
            _inventory.InventoryData.Clear();

            for (int i = 0; i < _inventory.InventoryData.maxSlots; i++)
            {
                _inventory.InventoryData.slots.Add(new Slot());
            }

            if (_inventory.InventoryData.startItems.Count != 0 && _inventory.InventoryData.startItems.Count == _inventory.InventoryData.startItemsCount.Count)
            {
                for (int i = 0; i < _inventory.InventoryData.startItems.Count; i++)
                {
                    _inventory.AddItem(_inventory.InventoryData.startItems[i], _inventory.InventoryData.startItemsCount[i]);
                }
            }
        }
    }

    public void Save()
    {
        _player.PlayerData.Save();
        _inventory.InventoryData.Save();
        _orderDesk.OrderData.Save();
    }

    public void LoadScene(int index)
    {
        if (index < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index);
        }
    }

    public void QuitInMainMenu()
    {
        LoadScene(0);
    }
}
