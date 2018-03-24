using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds the logic behind the Boost-PowerUp
/// </summary>
public class Boost : PowerUp {

    // Construct a new Boost-Object
    public Boost()
    {
        //Get the world config, with data for this powerup
        World_Config config = GameObject.Find("World_Config").GetComponent<World_Config>();

        // All properties are inherit from superclass PowerUp
        // Set activetime
        activetime = config.activetime_boost;

        // Set cooldowntime
        cooldowntime = config.cooldowntime_boost;

        // Set is_available
        is_availabe = true;
    }

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

    /// <summary>
    ///  Override standard method StartCooldown with specific method for this PowerUp
    /// </summary>
    
    // WARNING !!! Script is actual not functional !!! -> Need implementation of Timer

    public override void StartCooldown()
    {
        int acutalcooldown = cooldowntime;
        while(acutalcooldown > 0)
        {
            acutalcooldown--;
        }
        if(acutalcooldown == 0)
        {
            is_availabe = true;
        }
    }

    /// <summary>
    /// This method overrides the standard method with more specific instructions
    /// If this powerup is not in cooldown and available -> PowerUPAction
    /// </summary>
    public override void StartPowerUp()
    {
        if(is_availabe)
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

    public override void PowerUpAction()
    {
        Debug.Log("PowerUpAction started");
        // Find Player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        /*
        int actual_activetime = activetime;

        while(actual_activetime <0)
        {
            player.GetComponent<Rigidbody2D>().velocity.Scale(new Vector2(2, 2));
        }

        if(actual_activetime ==0)
        {
            StartCooldown();
        }
       */

    }
}
