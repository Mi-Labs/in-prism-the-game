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

        for(int i=0; i < buttons.Length;i++)
        {
            powerups[i] = buttons[i].gameObject;
        }

        AddPowerUpScripts();
        
    }
    

    /// <summary>
    /// This method toogle the powerupmenu screen
    /// </summary>
    void ToggleCanvas(bool _status)
    {
        Debug.Log("CanvasToogle: " + _status);
        m_powerupCanvas.enabled = (_status) ? true: false;
      
    }


    public void MakePowerUpVisible(System.String _name)
    {
        if (_name.Equals("Boost"))
        {
            powerups[0].GetComponent<Image>().enabled = true;
        }
        else if (_name.Equals("PowerJump"))
        {
            powerups[1].GetComponent<Image>().enabled = true;
        }
        else if (_name.Equals("PowerLight"))
        {
            powerups[2].GetComponent<Image>().enabled = true;
        }
        else if (_name.Equals("Sticky"))
        {
            powerups[3].GetComponent<Image>().enabled = true;
        }
        else if (_name.Equals("Invulnerablity"))
        {
            powerups[4].GetComponent<Image>().enabled = true;
        }
    }

    /// <summary>
    /// This method toggles between an active and an inactive powerupmenu screen
    /// </summary>
    public void ToogleMenu()
    {
        // if the canvas is deactivated -> do this
        if(!m_powerupCanvas.enabled)
        {
            ToggleCanvas(true);
           // Time.timeScale = 0.1f;
          //  Debug.Log("Opened Canvas");
        }
        else
        {
            ToggleCanvas(false);
          //  Time.timeScale = 1.0f;
            // Debug.Log("Closed Canvas");
        }
    }



    private void AddPowerUpScripts()
    {
        powerups[0].AddComponent<Boost>();
        powerups[1].AddComponent<PowerJump>();
        powerups[2].AddComponent<Power_Light>();
        powerups[3].AddComponent<Sticky>();
        powerups[4].AddComponent<Invulnerablity>();
    }
    

    /// <summary>
    /// This method starts the powerup action that is assigned to the specific powerup
    /// </summary>
    /// <param name="number">Position of PowerUp in powerups[]</param>
    public void StartPowerUP(int _number)
    {
        // Check if number is in the correct range
        if(_number < powerups.Length && _number >= 0)
        {
           switch(_number)
            {
                case 0:
                    powerups[_number].GetComponent<Boost>().StartPowerUp();
                    break;

                case 1:
                    powerups[_number].GetComponent<PowerJump>().StartPowerUp();
                    break;

                case 2:
                    powerups[_number].GetComponent<Power_Light>().StartPowerUp();
                    break;

                case 3:
                    powerups[_number].GetComponent<Sticky>().StartPowerUp();
                    break;

                case 4:
                    powerups[_number].GetComponent<Invulnerablity>().StartPowerUp();
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
