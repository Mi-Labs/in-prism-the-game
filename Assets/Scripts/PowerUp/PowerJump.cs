using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerJump : MonoBehaviour, IPowerUp {

    // holds the strength of the boost
    private float jump_strength;

    // Hold the time, that this powerUp is active
    private int activetime;

    // Hold the time that this powerUp needs to cool down
    private int cooldowntime;

    /* Hold the status of this PowerUP
     * true = player can use this powerUp
     * false = player can't use this powerUp */ 
    private bool isAvailable;


    /* Hold the status of cooldown
     * true = Cooldown is active 
     * false = Cooldown is not active */
    private bool cooldownIsActive;

    // Holds the preFab timer
    private GameObject timer;

    // Holds the player object
    private GameObject m_player;

	// Use this for initialization
	void Start ()
    {
        //Get the world config, with data for this powerup
        World_Config config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();

        // Set activetime
        activetime = config.activetime_jump;

        // Set cooldowntime
        cooldowntime = config.cooldowntime_jump;

        // Set boost strength
        jump_strength = config.extrajumppower;

        // Set cooldown-phase for this PowerUp to false (no active cooldown)
        cooldownIsActive = false;

        // Set is_available // Currently for tests -> normal activation trough powerupmenu
        isAvailable = true;

        // Find the player and assign it to player
        m_player = GameObject.FindGameObjectWithTag("Player");

        // Get the prefab-timer
        timer = config.timer;
     }

    /// <summary>
    ///  Cooldown-Mechanic. Starts the specific cooldown
    /// </summary>
    public void StartCooldown()
    {
        Debug.Log("Cooldown has started");

        // Set boostfactor to normal
        m_player.GetComponent<Player_Movement>().SetJumpFactorToStandard();

        // Start Cooldown-Timer
        StartTimer(cooldowntime);

        // Set cooldownphase to not active
        cooldownIsActive = false;
    }

    /// <summary>
    /// This method is called to start the powerUp, if available
    /// </summary>
    public void StartPowerUp()
    {
        if(isAvailable)
        {
            GameObject.Find("PowerUpMenu").GetComponent<PowerUp_Menu>().ToogleMenu();

            PowerUpAction();
        }
        else
        {
            // Debug.Log("PowerUp is not ready");
        }
    }

    /// <summary>
    /// This method start the action of the powerUp (also a countdown)
    /// </summary>
    public void PowerUpAction()
    {
        //Debug.Log("PowerUpAction started");

        // Start timer with the active power up time
        StartTimer(activetime);

        // Debug.Log(m_player);

        // Override the standard boostfactor
        m_player.GetComponent<Player_Movement>().SetJumpFactor(jump_strength);

        // Set cooldown phase to active
        cooldownIsActive = true;
    }

    /// <summary>
    ///  This method starts a timer with an specific time to run
    /// </summary>
    /// <param name="time">Active Time of the timer, in Seconds</param>
    public void StartTimer(int _time)
    {
        

        // Generate a cloned timer as GameObject
        GameObject timerClone = Instantiate(timer, transform.position, Quaternion.identity, transform) as GameObject;

        // Start the timer with the given parameter
        timerClone.BroadcastMessage("StartTimer", _time);

        //Debug.Log("Started Timer with " + time + " seconds");
    }

    /// <summary>
    ///  If the time of the timer is up, then this method should be called.
    ///  If the powerup was used, then the cooldown starts and you should access this powerUp
    /// </summary>
    public void TimeIsUp()
    {
        if (cooldownIsActive)
        {
            // Start the cooldown timer
            StartCooldown();

            // Make the powerUp unavailable for the player
            isAvailable = false;
        }
        else
        {
            isAvailable = true;
            // Debug.Log("Boost is ready again");
        }
    }
}
