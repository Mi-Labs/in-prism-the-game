﻿using System.Collections;
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

    public int m_Deaths;


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
        else
        {
            Debug.Log("Create new GlobalStatistic");
            m_Stats = new GlobalStatistics();
        }
    }

    private void LateUpdate()
    {
        //m_Deaths = GlobalStatistics.m_numberOfDeath;
      //  Debug.Log(GlobalStatistics.m_numberOfDeath);
    }

    public StatisticsSave SaveData()
    {
        return new StatisticsSave(m_Stats);
    }

    public void LoadStats(StatisticsSave _savedData)
    {
        if(_savedData != null)
        {
            string save =_savedData.GetSaveData().ToString();
            string[] data = save.Split('$');
            m_Deaths = 0;
            int.TryParse(data[0], out m_Deaths);
        }
    }


    private void OnApplicationQuit()
    {
       BinarySerializer.SaveStats(SaveData());
    }

}


