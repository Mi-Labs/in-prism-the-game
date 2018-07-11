using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinarySerializer : MonoBehaviour {

    private static string m_FilePathSaveGame;
    private static string m_FilePathStats;

    private static WorldSave m_Save;

    private static StatisticsSave m_Stats;

    private void Awake()
    {
        m_FilePathSaveGame = Path.Combine(Application.persistentDataPath, "game.save");
        m_FilePathStats = Path.Combine(Application.persistentDataPath, "game.stats");
    }

    public static void SaveGame(WorldSave _save)
    {
        m_Save = _save;
        BinaryFormatter bf = new BinaryFormatter();
        SaveLevel(bf);
    }

    private static void SaveLevel(BinaryFormatter _bf)
    {
        if(m_Save != null)
        {
            using (FileStream stream = new FileStream(m_FilePathSaveGame, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                _bf.Serialize(stream, m_Save);
            }
            Debug.Log("Level serialized");
        }
    }

    public static void LoadSaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();

        if (!LoadSaveGame(bf))
        {
            Debug.Log("No saved data found");
        }
        else
        {
            WorldObjectSave worldObjectSave = GameObject.FindGameObjectWithTag("LevelSave").GetComponent<WorldObjectSave>();
            worldObjectSave.LoadLevelList(m_Save);
        }   
    }

    private static bool LoadSaveGame(BinaryFormatter bf)
    {
        if (!File.Exists(m_FilePathSaveGame))
        {
            return false;
        }

        using (FileStream stream = new FileStream(m_FilePathSaveGame, FileMode.Open, FileAccess.Read))
        {
            m_Save = bf.Deserialize(stream) as WorldSave;
        }

        return true;
    }


    /* Methods for saving stats */

    public static void SaveStats(StatisticsSave _stats)
    {
        m_Stats = _stats;
        BinaryFormatter bf = new BinaryFormatter();
        SaveStatistics(bf);
    }

    private static void SaveStatistics(BinaryFormatter _bf)
    {
        if (m_Stats != null)
        {
            using (FileStream stream = new FileStream(m_FilePathStats, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                _bf.Serialize(stream, m_Stats);
            }
            Debug.Log("Statistics are serialized");
        }
    }

    public static void LoadStats()
    {
        BinaryFormatter bf = new BinaryFormatter();

        if (!LoadStats(bf))
        {
            Debug.Log("No saved data found");
        }
        else
        {
            World_Stats worldObjectSave = GameObject.FindGameObjectWithTag("Statistics").GetComponent<World_Stats>();
            worldObjectSave.LoadStats(m_Stats);
        }
    }

    /// <summary>
    /// This method deserialize the saved stats
    /// </summary>
    /// <param name="bf">BinaryFormatter for deserializing </param>
    /// <returns>Returns false, if there is no file</returns>
    private static bool LoadStats(BinaryFormatter bf)
    {
        // If there is no existing file, return false
        if (!File.Exists(m_FilePathStats))
        {
            return false;
        }

        // Deserialize saved statistics
        using (FileStream stream = new FileStream(m_FilePathStats, FileMode.Open, FileAccess.Read))
        {
            m_Stats = bf.Deserialize(stream) as StatisticsSave;
        }
        return true;
    }
}
