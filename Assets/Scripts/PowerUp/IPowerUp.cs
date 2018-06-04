using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This abstract class is the basic structure for all PowerUps
/// </summary>

public interface IPowerUp {

    /// <summary>
    /// This method should activate the cooldown, when the active time is over
    /// </summary>
     void StartCooldown();

    /// <summary>
    /// This method should be activate the PowerUp
    /// </summary>
     void StartPowerUp();

    /// <summary>
    /// This method activates the logic of the PowerUp -> Usually started with StartPowerUP()
    /// </summary>
    void PowerUpAction();


    /// <summary>
    /// This method should activate a timer 
    /// </summary>
    /// <param name="time"></param>
    void StartTimer(int time);


    /// <summary>
    /// This method should be called, when the time of the countdown is up
    /// </summary>
    void TimeIsUp();
}
