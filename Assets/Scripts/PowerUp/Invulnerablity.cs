using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerablity : MonoBehaviour, IPowerUp {


    /* Variables */


    // Hold the time, that this powerUp is active
    private int m_activetime;

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
    private GameObject player;



    /* Methods */


    // Use this for initialization
    void Start ()
    {
        //Get the world config, with data for this powerup
        World_Config config = GameObject.Find("World_Config").GetComponent<World_Config>();
       
        // Set activetime
        m_activetime = config.activetime_jump;

        // Set cooldowntime
        cooldowntime = config.cooldowntime_jump;

        // Set cooldown-phase for this PowerUp to false (no active cooldown)
        cooldownIsActive = false;

        // Set is_available // Currently for tests -> normal activation trough powerupmenu
        isAvailable = true;

        // Find the player and assign it to player
        player = GameObject.FindGameObjectWithTag("Player");

        // Get the prefab-timer
        timer = config.timer;
    }


    /// <summary>
    ///  Cooldown-Mechanic. Starts the spezific cooldown
    /// </summary>
    public void StartCooldown()
    {
        Debug.Log("Cooldown has started");

        // Toogle invulnerabilty to false
        player.GetComponent<HealthPlayer>().ToogleIsInvulnerable(false);

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
        if (isAvailable)
        {
            // Find the PowerUpMenu and then close it
            GameObject.Find("PowerUpMenu").GetComponent<PowerUp_Menu>().ToogleMenu();

            // Start the PowerUpAction
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
        StartTimer(m_activetime);

        // Toggle the invulnerablity in the health script
        player.GetComponent<HealthPlayer>().ToogleIsInvulnerable(true);

        // Set cooldown phase to active
        cooldownIsActive = true;
    }

    /// <summary>
    ///  This method starts a timer with an spezific time to run
    /// </summary>
    /// <param name="time">Active Time of the timer, in Seconds</param>
    public void StartTimer(int time)
    {
        // Generate a cloned timer as GameObject
        GameObject timerClone = Instantiate(timer, this.transform.position, Quaternion.identity, this.transform) as GameObject;

        // Start the timer with the given parameter
        timerClone.SendMessage("StartTimer", time);

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