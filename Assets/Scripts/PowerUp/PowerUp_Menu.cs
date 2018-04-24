using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp_Menu : MonoBehaviour {

    //Holds the menucanvas -> must be assigned
    public GameObject powerupCanvas;

    //Holds all available powerups in Array
    [SerializeField]
    public GameObject[] powerups;

    
    void Start()
    {
        //Create a new array with space for 5 powerups
        powerups = new GameObject[5];

        //Generate new GameObjects (for each poweruo)

        GameObject boost = new GameObject("Boost");
        // Add boost-script to GameObject 
        boost.AddComponent<Boost>();
        

        GameObject powerjump = new GameObject("PowerJump");
        // Add powerjump-script to GameObject 
        powerjump.AddComponent<PowerJump>();

        GameObject sticky = new GameObject("Sticky");
        // Add sticky-script to GameObject 
        sticky.AddComponent<Sticky>();

        GameObject invulnerablity = new GameObject("Invulnerablity");
        // Add invulnerability-script to GameObject 
        invulnerablity.AddComponent<Invulnerablity>();

        GameObject powerlight = new GameObject("PowerLight");
        // Add powerlight-script to GameObject 
        powerlight.AddComponent<Power_Light>();

        // Get every powerUp on a specific position
        powerups[0] = boost;
        powerups[1] = powerjump;
        powerups[2] = sticky;
        powerups[3] = invulnerablity;
        powerups[4] = powerlight;
    }
    

    /// <summary>
    /// This method activate the powerupmenu screen
    /// </summary>
    void OpenMenu()
    {
        powerupCanvas.SetActive(true);
        CheckAvailabePowerUp();
    }

    /// <summary>
    /// This method deactivate the powerupmenu screen
    /// </summary>
    void CloseMenu()
    {
        powerupCanvas.SetActive(false);
    }

    /// <summary>
    /// This method toggles between an active and an inactive powerupmenu screen
    /// </summary>
    public void ToogleMenu()
    {
        // if the canvas is deactivated -> do this
        if (!powerupCanvas.activeSelf)
        {
            OpenMenu();
            Debug.Log("Opened Canvas");
        }
        else
        {
            CloseMenu();
            Debug.Log("Closed Canvas");
        }
    }


    /// <summary>
    /// This method checks if a powerup is available.
    /// If so, the button for the powerup will be interactable
    /// </summary>
    private void CheckAvailabePowerUp()
    {
        //Find the world statistics
        World_Stats stats = GameObject.FindObjectOfType<World_Stats>();

        //Save all buttons in the powerupCanvas and save them to Array
        Button[] powerup_buttons = powerupCanvas.GetComponentsInChildren<Button>();

        //Iterate through all buttons
        foreach (Button powerup_button in powerup_buttons)
        {
            //Boost
            if (powerup_button.gameObject.name.Equals("PowerUp_Boost"))
            {
                //if the boost is available
                if (stats.powerup_boost)
                {
                    Debug.Log("Boost is available");
                    powerup_button.interactable = true;
                }
            }

            // PowerJump
            if (powerup_button.gameObject.name.Equals("PowerUp_Jump"))
            {
                if (stats.powerup_powerjump)
                {
                    //if power jump is available
                    Debug.Log("PowerJump is available");
                    powerup_button.interactable = true;
                }
            }

            // Light
            if (powerup_button.gameObject.name.Equals("PowerUp_Light"))
            {
                if (stats.powerup_powerlight)
                {
                    Debug.Log("Light is available");
                    powerup_button.interactable = true;
                }
            }
            //Invulnerable
            if (powerup_button.gameObject.name.Equals("PowerUp_Invulnerability"))
            {
                if (stats.powerup_invulnerable)
                {
                    Debug.Log("Invulnerability is available");
                    powerup_button.interactable = true;
                }
            }

            //Sticky
            if (powerup_button.gameObject.name.Equals("PowerUp_Sticky"))
            {
                if (stats.powerup_sticky)
                {
                    Debug.Log("Sticky is available");
                    powerup_button.interactable = true;
                }
            }
        }
        
    }

    /// <summary>
    /// This method starts the powerup action that is assigend to the spezific powerup
    /// </summary>
    /// <param name="number">Position of PowerUp in powerups[]</param>
    public void StartPowerUP(int number)
    {
        // Check if number is in the correct range
        if(number < 6 && number >= 0)
        {
           switch(number)
            {
                case 0:
                    powerups[number].GetComponent<Boost>().StartPowerUp();
                    break;

                case 1:
                    powerups[number].GetComponent<PowerJump>().StartPowerUp();
                    break;

                case 2:
                    powerups[number].GetComponent<Sticky>().StartPowerUp();
                    break;

                case 3:
                    powerups[number].GetComponent<Invulnerablity>().StartPowerUp();
                    break;

                case 4:
                    powerups[number].GetComponent<Power_Light>().StartPowerUp();
                    break;

                default:
                    //if the number is invalid -> throw IndexOutofRange
                    throw new System.IndexOutOfRangeException();
            }
        }
        // if number is incorrect
        else
        {
            throw new System.IndexOutOfRangeException();
        }
        
    }
}
