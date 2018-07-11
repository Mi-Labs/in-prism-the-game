using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

/// <summary>
/// This class holds the statistics over the whole game
/// Also it saves the progress of the player
/// </summary>


public class World_Stats : MonoBehaviour
{
    /* Fields */

    // Holds the only instance for script
    public static World_Stats instance = null;

    public GlobalStatistics m_Stats;


    /* Methods */

    //Is called when Script is loaded the first time
    private void Awake()
    {
        /* Singleton Pattern */
        // If no other instance is there -> save this instance
        if (instance == null)
        {
            instance = this;
        }

        // If another instance is already there -> destroy this
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    /// <summary>
    ///  Is called after Awake()
    /// </summary>
    private void Start()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "game.stats");
        if (File.Exists(filePath))
        {
            BinarySerializer.LoadStats();
        }
    }

    public StatisticsSave SaveData()
    {
        return new StatisticsSave(m_Stats);
    }

    public void LoadStats(StatisticsSave _savedData)
    {
        if(_savedData != null)
        {
            m_Stats = _savedData.GetSaveData();
        }
    }
}

