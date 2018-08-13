using System;
using UnityEngine;
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

    public string m_PlayTimeInSeconds;

    private float m_TotalPlayedTime;




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
            m_Stats = GlobalStatistics.Instance;
        }
    }

    /// <summary>
    /// This method generates a statistic save and returns it 
    /// </summary>
    /// <returns>saved statistic data</returns>
    public StatisticsSave SaveData()
    {
        return new StatisticsSave(m_Stats);
    }

    /// <summary>
    /// This method loads the data from a serialized data
    /// </summary>
    /// <param name="_savedData">Serialized statistic data</param>
    public void LoadStats(StatisticsSave _savedData)
    {
        if(_savedData != null)
        {
            // Set Global Statistics
            m_Stats = GlobalStatistics.Instance;

            // Set Number of Deaths
            m_Stats.SetNumberOfDeath(_savedData.GetSaveData().GetNumberOfDeath());

            // Set Play Time
            m_Stats.SetPlayTime(_savedData.GetSaveData().GetPlayTime());

            // Convert PlayTime to readable format
            m_PlayTimeInSeconds = TimeSpan.FromSeconds(m_Stats.GetPlayTime()).ToString();
        }
    }

    
    /// <summary>
    /// If the application is quit, save the statistics
    /// </summary>
    private void OnApplicationQuit()
    {

       m_TotalPlayedTime = Time.timeSinceLevelLoad;
       m_Stats.UpdatePlayTime(m_TotalPlayedTime);

       BinarySerializer.SaveStats(SaveData());
    }

    public GlobalStatistics GetStats()
    {
        return m_Stats;
    }
}


