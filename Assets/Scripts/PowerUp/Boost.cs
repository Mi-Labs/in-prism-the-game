using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class holds the logic behind the Boost-PowerUp
/// </summary>
public class Boost : MonoBehaviour, IPowerUp {

    public float boost_strength;

    private int activetime;

    private int cooldowntime;

    private bool isAvailable;

    private bool cooldownIsActive;

    public GameObject timer;

	// Use this for initialization
	void Start ()
    {
        //Get the world config, with data for this powerup
        World_Config config = GameObject.Find("World_Config").GetComponent<World_Config>();

        // All properties are inherit from superclass PowerUp
        // Set activetime
        activetime = config.activetimeBoost;

        // Set cooldowntime
        cooldowntime = config.cooldowntimeBoost;

        // Set is_available
        isAvailable = true;

        // Set boost strength
        boost_strength = config.strenghtBoost;

        cooldownIsActive = false;
    }
	
	// Update is called once per frame
	void Update () {}

    /// <summary>
    ///  Override standard method StartCooldown with specific method for this PowerUp
    /// </summary>
    
    // WARNING !!! Script is actual not functional !!! -> Need implementation of Timer

    public void StartCooldown()
    {
        cooldownIsActive = false;
        Debug.Log("Cooldown has started");
        StartTimer(cooldowntime);
    }

    /// <summary>
    /// This method overrides the standard method with more specific instructions
    /// If this powerup is not in cooldown and available -> PowerUPAction
    /// </summary>
    public void StartPowerUp()
    {
        if(isAvailable)
        {
            // Close PowerUpMenu Screen
            GameObject.Find("PowerUpMenu").GetComponent<PowerUp_Menu>().ToogleMenu();
            PowerUpAction();

        }
       else
        {
            Debug.Log("PowerUp is not ready");
        }
        
    }

    /// <summary>
    /// This method overrides the standard method with more specific instructions
    /// This method contains the heart of the powerup -> the mechanic 
    /// </summary>
    /// 

    // WARNING !!! This method is actual not functional !!! -> Need implementation of Timer and refactoring of Playermovement

    public void PowerUpAction()
    {
        Debug.Log("PowerUpAction started");
        // Find Player
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float oldboost = player.GetComponent<Player_Movement>().boostfactor;

        StartTimer(activetime);
        cooldownIsActive = true;

    }

    public void StartTimer (int time)
    {
        GameObject timerClone = Instantiate(timer, this.transform.position, Quaternion.identity, this.transform) as GameObject;
        timerClone.SendMessage("StartTimer", time);
        Debug.Log("Started Timer with " + time + " seconds");
    }

    public void TimeIsUp()
    {
        if(cooldownIsActive)
        {
            StartCooldown();
        }
        else
        {
            Debug.Log("Cooldown is active");
        }
    }
}
