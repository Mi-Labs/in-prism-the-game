using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WorldObjectSave : MonoBehaviour {

    /* Fields */

    // Holds a list with all saved levels
    public List<LevelSave> m_levelSaves = new List<LevelSave>();


    /* Methods */

    public void Start()
    {
        // Generate savegame file path
        string filePath = Path.Combine(Application.persistentDataPath, "game.save");

        // If a savegame exists -> Load that
        if (File.Exists(filePath))
        {
            BinarySerializer.LoadSaveGame();
        }
    }


    /// <summary>
    /// This method adds a LevelSave to the saving list
    /// </summary>
    /// <param name="_save">Level to add</param>
    public void AddLevelSave(LevelSave _save)
    {
        // Search if the level is already in list
        LevelSave savedlevel = SearchForLevel(_save);

        // If the level is not saved before ...
        if (savedlevel == null)
        {
            m_levelSaves.Add(_save);
        }
        else
        {
            // Remove old save -> Add new save
            m_levelSaves.Remove(savedlevel);
            m_levelSaves.Add(_save);
        }
    }


    /// <summary>
    /// Check if a level already exists
    /// </summary>
    /// <param name="_save">Level, that should searched for</param>
    /// <returns>If level is found, return true</returns>
    private bool LevelSaveExists(LevelSave _save)
    {
        return SearchForLevel(_save) != null ? true : false;
    }


    /// <summary>
    /// This method search for a level in the levellist
    /// </summary>
    /// <param name="_save">Level to search for</param>
    /// <returns>If Level was found, return this, else null</returns>
    private LevelSave SearchForLevel(LevelSave _save)
    {
        // Get levelnumber from the given LevelSave
        int newLevelnumber = _save.m_levelnumber;
        // Search all LevelSaves
        foreach (LevelSave save in m_levelSaves)
        {
            // If a level in the list has the same number as the given level
            if (save.m_levelnumber.Equals(newLevelnumber))
            {
                return save;
            }
        }
        return null;
    }


    /// <summary>
    /// This method loads a given WorldSave data
    /// </summary>
    /// <param name="_savedata">The WorldSave, that should be loaded</param>
    public void LoadLevelList(WorldSave _savedata)
    {
        // When the saved data is not null, load the data from the given WorldSave
        if(_savedata != null)
        {
            m_levelSaves = _savedata.GetSaveData();
        }
    }


    /// <summary>
    /// This method returns the List of all LevelSaves
    /// </summary>
    /// <returns>The actual saved List of LevelSaves</returns>
    public List<LevelSave> GetLevelSaves()
    {
        return m_levelSaves;
    }

    /// <summary>
    /// This method saves the actual Data
    /// </summary>
    /// <returns>Returns the actual</returns>
    public WorldSave SaveData()
    {
        return new WorldSave(m_levelSaves);
    }
}