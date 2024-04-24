using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

/// <summary>
/// Класс хранения информации о игроке
/// </summary>
[CreateAssetMenu(fileName = "PlayerData", menuName = "Farm/Data/Player", order = 0)]
public class PlayerData : ScriptableObject
{
    public int money = 30;
    public int exp = 0;
    public int maxExp = 100;
    public int level = 1;

    public void Save()
    {
        PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(this));
    }

    public bool Load()
    {
        if (PlayerPrefs.HasKey("PlayerData"))
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("PlayerData"), this);
            return true;
        }
        return false;
    }

    public void Clear()
    {
        money = 30;
        exp = 0;
        maxExp = 100;
        level = 1;
    }
}
