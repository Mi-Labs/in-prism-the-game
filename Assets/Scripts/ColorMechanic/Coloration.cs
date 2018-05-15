using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class saves the original color of the gameobject
/// -> Must be attached to every object with colorchanging mechanic
/// </summary>
public class Coloration : MonoBehaviour {


    /* Variables */

    // Holds color to colorize grayscale GO
    public Color origincolor;

    // Holds boolean (if true -> color should be applied to GO)
    private bool is_colorful;


    /* Methods */

    // Use this for initialization
    void Start ()
    {
        is_colorful = false;	
	}

    /// <summary>
    /// This method returns the color that is saved in this script
    /// </summary>
    /// <returns>The original color for this object</returns>
    public Color GetColor()
    {
        return origincolor;
    }
    
    /// <summary>
    ///  This method gets the status of the colorfullness of the object
    /// </summary>
    /// <returns>The status of the colorfullness</returns>
    public bool GetIsColorful()
    {
        return is_colorful;
    }

    /// <summary>
    /// If this method is called, the GameObject changes to the saved color
    /// </summary>
    public void ActivateColor()
    {
        // Change the color of this GameObjects SpriteRenderer to the assigned color
        this.gameObject.GetComponent<SpriteRenderer>().color = this.GetColor();
        
        // Debug.Log(this.GetColor() +" Color sucessfully changed");

        // Set the colorfullness to true
        is_colorful = true;
    }
}
