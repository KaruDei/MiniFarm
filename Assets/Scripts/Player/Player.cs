using UnityEngine;

/// <summary>
/// Класс реализующий функционал игрока
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private PlayerData _playerData;
    public PlayerData PlayerData => _playerData;
    public Inventory Inventory => _inventory;

    private void Start()
    {
        if (!_playerData.Load())
        {
            _playerData.money = 30;
            _playerData.exp = 0;
            _playerData.maxExp = 100;
            _playerData.level = 1;
        }
    }

    public void AddMoney(int money)
    {
        PlayerData.money += money;
    }

    public void RemoveMoney(int money)
    {
        PlayerData.money -= money;
    }

    public void AddExp(int exp)
    {
        PlayerData.exp += exp;

        if (PlayerData.exp >= PlayerData.maxExp)
        {
            PlayerData.exp -= PlayerData.maxExp;
            PlayerData.maxExp = Mathf.RoundToInt(PlayerData.maxExp * 1.75f);
            LevelUp();
        }
    }

    public void LevelUp()
    {
        PlayerData.level++;
    }
}
