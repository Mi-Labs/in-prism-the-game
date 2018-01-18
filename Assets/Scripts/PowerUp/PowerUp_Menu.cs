using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Menu : MonoBehaviour {

    //Holds the menucanvas -> must be assigned
    public GameObject powerupCanvas;


    /// <summary>
    /// This method activate the powerupmenu screen
    /// </summary>
    void OpenMenu()
    {
        powerupCanvas.SetActive(true);
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
            Time.timeScale = 0;
            Debug.Log("Opened Canvas");
        }
        else
        {
            CloseMenu();
            Time.timeScale = 1;
            Debug.Log("Closed Canvas");
        }
    }
}
