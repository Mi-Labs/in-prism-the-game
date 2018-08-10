using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp_Menu : MonoBehaviour {

    //Holds the menucanvas -> must be assigned
    private Canvas m_powerupCanvas;

    //Holds all available powerups in Array
    [SerializeField]
    public GameObject[] powerups;


    void Start()
    {
        // Register the PowerUpMenu in the player
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Control>().AddPowerUpMenu();

        m_powerupCanvas = gameObject.GetComponentInChildren<Canvas>();

        //Create a new array with space for 5 powerups
        powerups = new GameObject[5];

        Button[] buttons = gameObject.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].gameObject.name.Contains("PowerUp"))
            {
                powerups[i] = buttons[i].gameObject;
            }
            
        }

        CheckForVisiblePowerUps();

        ToggleCanvas(false);
    }

    /// <summary>
    /// This method checks, what powerUps are available for the player
    /// </summary>
    private void CheckForVisiblePowerUps()
    {
        // Find config data
        World_Config config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();

        // Create a bool array for status of availability of powerups
        bool[] availablePowerups = new bool[5];

        // Fill the array
        availablePowerups[0] = config.isAvailableBoost;
        availablePowerups[1] = config.isAvailablePowerJump;
        availablePowerups[2] = config.isAvailablePowerLight;
        availablePowerups[3] = config.isAvailableSticky;
        availablePowerups[4] = config.isAvailableInvulnerability;

        // Iterate through the array
        for (int i=0;i < availablePowerups.Length;i++)
        {
            // If a powerUp is available -> Make it visible
            if(availablePowerups[i])
            {
                MakePowerUpVisible(i);
            }
        }
    }


    /// <summary>
    /// This method toggle the powerup-menu screen
    /// </summary>
    void ToggleCanvas(bool _status)
    { 
        m_powerupCanvas.enabled = (_status) ? true: false;   
    }

    /// <summary>
    /// This method makes a specific powerup visible
    /// </summary>
    /// <param name="_powerupNumber">Number of the powerup</param>
    public void MakePowerUpVisible(int _powerupNumber)
    {
        if(_powerupNumber >=0 && _powerupNumber <5)
        {
            powerups[_powerupNumber].SendMessage("MakePowerUpVisible");
        }
    }


    /// <summary>
    /// This method toggles between an active and an inactive powerup-menu screen
    /// </summary>
    public void ToggleMenu()
    {
        // If the canvas is deactivated...
        if(!m_powerupCanvas.enabled)
        {
            ToggleCanvas(true);
        }
        else
        {
            ToggleCanvas(false);
        }   
    }

    
    /// <summary>
    /// This method starts the powerup action that is assigned to the specific powerup
    /// </summary>
    /// <param name="number">Position of PowerUp in powerups[]</param>
    public void StartPowerUP(int _number)
    {
        // Check if number is in the correct range
        if(_number >= 0  && _number < powerups.Length)
        {
            powerups[_number].SendMessage("StartPowerUp");
        }
        else
        {
            throw new System.IndexOutOfRangeException();
        }
    }
}