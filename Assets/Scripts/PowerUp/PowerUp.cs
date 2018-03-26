using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This abstract class is the basic structure for all PowerUps
/// </summary>

public abstract class PowerUp {

    // Holds the duration of the powerup
    protected int activetime;

    // Holds the cooldownduration
    protected int cooldowntime;

    // Holds the status of this powerup
    protected bool is_availabe;


    /// <summary>
    /// This method should activate the cooldown, when the active time is over
    /// </summary>
    public abstract void StartCooldown();

    /// <summary>
    /// This method should be activate the PowerUp
    /// </summary>
    public abstract void StartPowerUp();

    /// <summary>
    /// This method activates the logic of the PowerUp -> Usually started with StartPowerUP()
    /// </summary>
    public abstract void PowerUpAction();
}
