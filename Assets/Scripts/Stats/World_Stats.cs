using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class holds the statistics over the whole game
/// Also it saves the progress of the player
/// </summary>

//Makes the stats saveable
[System.Serializable]

public class World_Stats : MonoBehaviour {

    // Holds the only instance for script
    public static World_Stats instance = null;

    //Save all levelstats in Array
    public Level_Stats[] level;

    //Hold the status of the powerup "boost"
    public bool powerup_boost;

    //Hold the status of the powerup "powerjump"
    public bool powerup_powerjump;

    //Hold the status of the powerup "light"
    public bool powerup_powerlight;

    //Hold the status of the powerup "ivulnerable"
    public bool powerup_invulnerable;

    //Hold the status of the powerup "sticky"
    public bool powerup_sticky;

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

        //This gameObject should not be destroyed on scene change.
        DontDestroyOnLoad(this);

        level = new Level_Stats[5];
       // powerup_boost = false;
        powerup_powerjump = false;
    }

    // Use this for initialization
    void Start ()
    {
        //assign the actual levelstats in the level[]
        level[SceneManager.GetActiveScene().buildIndex] = GameObject.FindObjectOfType<Level_Stats>(); 
	}
	
	
    /// <summary>
    ///  This method activates the avaiblity of the boost
    /// </summary>
    public void ActivatePowerUpBoost()
    {
        if (!powerup_boost)
            powerup_boost = true;
    }

    /// <summary>
    /// This method activates the availibility of the power jump
    /// </summary>
    public void ActivatePowerUpJump()
    {
        if(!powerup_powerjump)
        {
            powerup_powerjump = true;
        }
    }
}

