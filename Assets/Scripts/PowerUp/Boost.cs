using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : PowerUp {

	// Use this for initialization
	void Start ()
    {
        activetime = 2;
        cooldowntime = 10;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public override void StartCooldown()
    {
        throw new System.NotImplementedException();
    }

    public override void StartPowerUp()
    {
        Debug.Log("PowerUP gestartet");
        GameObject.Find("PowerUpMenu").GetComponent<PowerUp_Menu>().ToogleMenu();
    }
}
