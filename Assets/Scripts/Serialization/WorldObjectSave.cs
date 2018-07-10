using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WorldObjectSave : MonoBehaviour {

    public List<LevelSave> m_levelSaves = new List<LevelSave>();

    public void Start()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "game.save");
        if (File.Exists(filePath))
        {
            BinarySerializer.Load();
        }
    }

    public void AddLevelSave(LevelSave _save)
    {
        LevelSave savedlevel = SearchForLevel(_save);

        if (savedlevel == null)
        {
            m_levelSaves.Add(_save);
        }
        else
        {
            m_levelSaves.Remove(savedlevel);
            m_levelSaves.Add(_save);
        }
    }

    private bool LevelSaveExists(LevelSave _save)
    {
        return SearchForLevel(_save) != null ? true : false;
    }

    private LevelSave SearchForLevel(LevelSave _save)
    {
        int newLevelnumber = _save.m_levelnumber;
        foreach (LevelSave save in m_levelSaves)
        {
            if (save.m_levelnumber.Equals(newLevelnumber))
            {
                return save;
            }
        }
        return null;
    }

    public void LoadLevelList(WorldSave _savedata)
    {
        if(_savedata != null)
        {
            m_levelSaves = _savedata.GetSaveData();
        }
    }

    public List<LevelSave> GetLevelSaves()
    {
        return m_levelSaves;
    }

    public WorldSave SaveData()
    {
        return new WorldSave(m_levelSaves);
    }

}
