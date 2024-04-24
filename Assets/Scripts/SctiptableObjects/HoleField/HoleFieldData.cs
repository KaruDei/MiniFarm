using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс хранения данных о грядках
/// </summary>
[CreateAssetMenu(fileName = "HoleFieldData", menuName = "Farm/Data/HoleField", order = 0)]
public class HoleFieldData : ScriptableObject
{
    public List<GameObject> holes = new();

    public void Save()
    {

    }

    public void Load() 
    {

    }
}
