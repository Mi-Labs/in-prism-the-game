using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class holds the statistics over the whole game
/// Also it saves the progress of the player
/// </summary>

//Makes the stats savable
[System.Serializable]

public class World_Stats : MonoBehaviour
{

    // Holds the only instance for script
    public static World_Stats instance = null;


    public GlobalStatistics m_Stats;

    //Is called when Script is loaded the first time
    private void Awake()
    {
        /* Singleton Pattern */

        // If no other instance is there -> save this instance
        if (instance == null)
        {
            instance = this;
        }

        // if another instance is already there -> destroy this
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }
}

