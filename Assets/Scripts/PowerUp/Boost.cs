using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class holds the logic behind the Boost-PowerUp , implements IPowerUp
/// </summary>
public class Boost : MonoBehaviour, IPowerUp {

    // holds the strength of the boost
    private float boost_strength;

    // Hold the time, that this powerUp is active
    private int activetime;

    // Hold the time that this powerUp needs to cool down
    private int cooldowntime;

    /* Hold the status of this PowerUP
     * true = player can use this powerUp
     * false = player can't use this powerUp
     */
    private bool m_IsInteractable;

    /* Hold the status of cooldown
     * true = Cooldown is active 
     * false = Cooldown is not active
     */
    private bool cooldownIsActive;

    // Holds the preFab timer
    private GameObject timer;

    // Holds the player object
    private GameObject player;

    private PowerUpInteraction m_interaction;


    // Use this for initialization
    void Start ()
    {
        //Get the world config, with data for this powerup
        World_Config config = GameObject.Find("World_Config").GetComponent<World_Config>();

        // Set activetime
        activetime = config.activetimeBoost;

        // Set cooldowntime
        cooldowntime = config.cooldowntimeBoost;

        // Set is_available // Currently for tests -> normal activation trough powerupmenu
        m_IsInteractable = true;

        // Set boost strength
        boost_strength = config.strenghtBoost;

        // Set cooldown-phase for this PowerUp to false (no active cooldown)
        cooldownIsActive = false;

        // Find the player and assign it to player
        player = GameObject.FindGameObjectWithTag("Player");

        // Get the prefab-timer
        timer = config.timer;

        m_interaction = GetComponent<PowerUpInteraction>();

        // @Start the powerUp should be interactable
        m_IsInteractable = true;

        m_interaction.ToggleInteractibility(m_IsInteractable);
    }


    /// <summary>
    /// If this powerup is not in cooldown and available -> PowerUPAction
    /// </summary>
    public void StartPowerUp()
    {
        if(m_IsInteractable)
        {
            SendMessageUpwards("ToggleMenu");

            // Start the PowerUp mechanic
            PowerUpAction();
        }
    }

    /// <summary>
    /// This method contains the heart of the powerup -> the mechanic 
    /// </summary>
    public void PowerUpAction()
    {
        //Debug.Log("PowerUpAction started");

        // Start timer with the active power up time
        StartTimer(activetime);

        // Override the standard boostfactor
        player.GetComponent<Player_Movement>().boostfactor = boost_strength;

        // Set cooldown phase to active
        cooldownIsActive = true;
    }

    /// <summary>
    ///  This method starts a timer with an spezific time to run
    /// </summary>
    /// <param name="time">Active Time of the timer, in Seconds</param>
    public void StartTimer (int time)
    {
        // Generate a cloned timer as GameObject
        GameObject timerClone = Instantiate(timer, this.transform.position, Quaternion.identity, this.transform) as GameObject;

        // Start the timer with the given parameter
        timerClone.BroadcastMessage("StartTimer", time);

        //Debug.Log("Started Timer with " + time + " seconds");
    }


    /// <summary>
    ///  If the time of the timer is up, then this method should be called.
    ///  If the powerup was used, then the cooldown starts and you should access this powerUp
    /// </summary>
    public void TimeIsUp()
    {
        if(cooldownIsActive)
        {
            // Start the cooldown timer
            StartCooldown();
            
            // Make the powerUp unavailable for the player
            m_IsInteractable = false;
        }
        else
        {
            // Make the powerUp available again
            m_IsInteractable = true;
        }

        m_interaction.ToggleInteractibility(m_IsInteractable);
    }
    

    /// <summary>
    ///  Cooldown-Mechanic. Starts the specific cooldown
    /// </summary>
    public void StartCooldown()
    {
        // Debug.Log("Cooldown has started");

        // Set boostfactor to normal
        player.GetComponent<Player_Movement>().SetBoostSpeedToStandard();

        // Start Cooldown-Timer
        StartTimer(cooldowntime);

        m_interaction.StartCoolDownGraphic(cooldowntime);

        // Set cooldownphase to not active
        cooldownIsActive = false;
    }
}
