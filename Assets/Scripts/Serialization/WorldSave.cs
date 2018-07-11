using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldSave
{
    /* Fields */

    // Holds a list with all level saves
    public List<LevelSave> m_save;

    /* Constructor */

    public WorldSave(List<LevelSave> _saveData)
    {
        if(_saveData != null)
        {
            m_save = _saveData;
        }
        else
        {
            Debug.LogError("Invalid save data");
        }
    }

    /* Methods */

    /// <summary>
    /// This method returns the saved data
    /// </summary>
    /// <returns>returns the saved list of level saves</returns>
    public List<LevelSave> GetSaveData()
    {
        return m_save;
    }
}
