using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp_Menu : MonoBehaviour {

    //Holds the menucanvas -> must be assigned
    public GameObject m_powerupCanvas;

    //Holds all available powerups in Array
    [SerializeField]
    public GameObject[] powerups;

    public World_Config m_config;

    public GameObject m_powerUpContainer;


    void Start()
    {
        // Register the PowerUpMenu in the player
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Control>().AddPowerUpMenu();

        //Create a new array with space for 5 powerups
        powerups = new GameObject[5];

        Button[] buttons = m_powerUpContainer.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].gameObject.name.Contains("PowerUp"))
            {
                powerups[i] = buttons[i].gameObject;
            }         
        }

        m_config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();

        CheckForVisiblePowerUps();

    }

    /// <summary>
    /// This method checks, what powerUps are available for the player
    /// </summary>
    private void CheckForVisiblePowerUps()
    {
        // Find config data

        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        if(controller != null)
        {
            int actualLevelNumber = controller.GetComponent<Level_Stats>().GetLevelNumber();
            SetPowerUpConfig(actualLevelNumber);

        }
  
        
        // Create a bool array for status of availability of powerups
        bool[] availablePowerups = new bool[5];

        // Fill the array
        availablePowerups[0] = m_config.isAvailableBoost;
        availablePowerups[1] = m_config.isAvailablePowerJump;
        availablePowerups[2] = m_config.isAvailablePowerLight;
        availablePowerups[3] = m_config.isAvailableSticky;
        availablePowerups[4] = m_config.isAvailableInvulnerability;

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


    public void SetPowerUpConfig(int _number)
    {
        if(_number >=7)
        {
            m_config.isAvailableBoost = true;
        }

        if(_number >=12)
        {
            m_config.isAvailablePowerJump = true;
        }
        if(_number >= 17)
        {
            m_config.isAvailableSticky = true;
        }
        if(_number >=22)
        {
            m_config.isAvailableInvulnerability = true;
        }
        if(_number >= 31)
        {
            m_config.isAvailablePowerLight = true;
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