using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour, IPowerUp {

    // Hold the time, that this powerUp is active
    private int m_activetime;

    // Hold the time that this powerUp needs to cool down
    private int m_cooldowntime;

    /* Hold the status of this PowerUP
     * true = player can use this powerUp
     * false = player can't use this powerUp */
    private bool m_isAvailable;


    /* Hold the status of cool down
     * true = Cool down is active 
     * false = Cool down is not active */
    private bool m_cooldownIsActive;

    // Holds the preFab timer
    private GameObject m_timer;

    // Holds the player object
    private GameObject m_player;

    private static StickyForPlayer m_stickyScript;

    // Use this for initialization
    void Start ()
    {
        //Get the world config, with data for this power up
        World_Config config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();

        // Set m_activetime
        m_activetime = config.activetime_sticky;

        // Set cooldowntime
        m_cooldowntime = config.cooldowntime_sticky;

        m_stickyScript = null;   

        // Set cool down-phase for this PowerUp to false (no active cool down)
        m_cooldownIsActive = false;

        // Set is_available // Currently for tests -> normal activation trough powerupmenu
        m_isAvailable = true;

        // Find the player and assign it to player
        m_player = GameObject.FindGameObjectWithTag("Player");

        // Get the prefab-timer
        m_timer = config.timer;
    }
	

    public void StartCooldown()
    {
        m_stickyScript.enabled = false;

        // Start cooldown-Timer
        StartTimer(m_cooldowntime);

        // Set cool down phase to not active
        m_cooldownIsActive = false;
    }

    /// <summary>
    /// This method is called to start the powerUp, if available
    /// </summary>
    public void StartPowerUp()
    {
        if (m_isAvailable)
        {
            GameObject.Find("PowerUpMenu").GetComponent<PowerUp_Menu>().ToogleMenu();

            PowerUpAction();
        }
        else
        {
            // Debug.Log("PowerUp is not ready");
        }
    }

    public void PowerUpAction()
    {
        // Start timer with active power up time
        StartTimer(m_activetime);

       
        if(m_player.GetComponent<StickyForPlayer>() != null)
        {
            m_stickyScript = m_player.GetComponent<StickyForPlayer>();
            m_stickyScript.enabled = true;
        }
        else
        {
            m_stickyScript = m_player.AddComponent<StickyForPlayer>();
        }

        

        // Set cool down phase to active
        m_cooldownIsActive = true;
    }

    /// <summary>
    ///  This method starts a timer with an specific time to run
    /// </summary>
    /// <param name="time">Active Time of the timer, in Seconds</param>
    public void StartTimer(int time)
    {
        // Generate a cloned timer as GameObject
        GameObject timerClone = Instantiate(m_timer, this.transform.position, Quaternion.identity, this.transform) as GameObject;

        // Start the timer with the given parameter
        timerClone.SendMessage("StartTimer", time);

        //Debug.Log("Started Timer with " + time + " seconds");
    }

    /// <summary>
    ///  If the time of the timer is up, then this method should be called.
    ///  If the power up was used, then the cool down starts and you should access this powerUp
    /// </summary>
    public void TimeIsUp()
    {
        if (m_cooldownIsActive)
        {
            // Start the cool down timer
            StartCooldown();

            

            m_stickyScript.DestroyFakeGravity();

            // Make the powerUp unavailable for the player
            m_isAvailable = false;
        }
        else
        {
            m_isAvailable = true;
            // Debug.Log("Boost is ready again");
        }
    }
}
