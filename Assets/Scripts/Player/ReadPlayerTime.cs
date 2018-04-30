using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadPlayerTime : MonoBehaviour {

    // Holds the actual value of lifepoints
    private int lifepoints;

    // Holds the textfield of the canvas, that displays the lifepoints
    public Text lifetext;

    // Use this for initialization
	void Start ()
    {
        //Find the gameObject, that holds the textfield for lifepoints and save the text component to the variable
        lifetext = GameObject.Find("LifePlayerText").GetComponent<Text>();
        
        //Debug.Log(lifepoints);

        // Change the value of the textfield to actual value
        ChangeTextValue();
    }
	
    /// <summary>
    ///  This method changes the textfield to the actual value of the player lifepoints
    /// </summary>
    public void ChangeTextValue()
    {
        // Get the current lifepoints
        lifepoints = this.GetComponent<HealthPlayer>().GetLifePoints();

        // Write the current lifepoints to this textfield
        lifetext.text = lifepoints.ToString();
    }
}
