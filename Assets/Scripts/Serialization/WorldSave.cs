using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldSave
{
    public List<LevelSave> m_save;

    public WorldSave(List<LevelSave> _saveData)
    {
        if(_saveData != null)
        {
            m_save = _saveData;
        }
        else
        {
            Debug.LogError("Invalid save Data");
        }
    }

    public List<LevelSave> GetSaveData()
    {
        return m_save;
    }
	
}
