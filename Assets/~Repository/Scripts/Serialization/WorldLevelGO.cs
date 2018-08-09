using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldLevelGO
{

    /* Fields */

    // Holds every level save data
    public List<LevelSave> m_levelList = new List<LevelSave>();

    // Holds the object as singelton
    private static WorldLevelGO m_instance = null;

    // 
    public static WorldLevelGO Instance
    {
        get
        {
            return m_instance == null ? new WorldLevelGO() : WorldLevelGO.m_instance;
        }
    }



    /* Methods */

    public void AddLevelStat(LevelSave _save)
    {
        if (m_levelList.Count != 0)
        {
            if (m_levelList.Contains(_save))
            {
                m_levelList.Remove(_save);
                m_levelList.Add(_save);
            }
            else
            {
                m_levelList.Add(_save);
            }
        }
    }
}

