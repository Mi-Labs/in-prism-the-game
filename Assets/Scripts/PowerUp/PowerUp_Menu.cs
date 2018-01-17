using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Menu : MonoBehaviour {

    //private field (Holds the menucanvas)
    private Canvas powerupCanvas;

	// Use this for initialization
	void Start ()
    {
        powerupCanvas = GetComponentInChildren<Canvas>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OpenMenu()
    {
        powerupCanvas.gameObject.SetActive(true);

    }

    public void CloseMenu()
    {
        powerupCanvas.gameObject.SetActive(false);
    }
}
