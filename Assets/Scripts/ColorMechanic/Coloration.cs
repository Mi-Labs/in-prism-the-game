using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class saves the original color of the gameobject
/// -> Must be attached to every object with colorchanging mechanic
/// </summary>
public class Coloration : MonoBehaviour {

<<<<<<< HEAD
=======

    /* Variables */

>>>>>>> NightMasking
    // Holds color to colorize grayscale GO
    public Color origincolor;

    // Holds boolean (if true -> color should be applied to GO)
    private bool is_colorful;

<<<<<<< HEAD
	// Use this for initialization
	void Start ()
=======

    /* Methods */

    // Use this for initialization
    void Start ()
>>>>>>> NightMasking
    {
        is_colorful = false;	
	}

<<<<<<< HEAD
    // Update is called once per frame
    void Update() { }

=======
    /// <summary>
    /// This method returns the color that is saved in this script
    /// </summary>
    /// <returns>The original color for this object</returns>
>>>>>>> NightMasking
    public Color GetColor()
    {
        return origincolor;
    }
<<<<<<< HEAD




=======
    
    /// <summary>
    ///  This method gets the status of the colorfullness of the object
    /// </summary>
    /// <returns>The status of the colorfullness</returns>
>>>>>>> NightMasking
    public bool GetIsColorful()
    {
        return is_colorful;
    }

    /// <summary>
    /// If this method is called, the GameObject changes to the saved color
    /// </summary>
    public void ActivateColor()
    {
<<<<<<< HEAD
        this.gameObject.GetComponent<SpriteRenderer>().color = this.GetColor();
     //   Debug.Log(this.GetColor() +" Color sucessfully changed");
=======
        // Change the color of this GameObjects SpriteRenderer to the assigned color
        this.gameObject.GetComponent<SpriteRenderer>().color = this.GetColor();
        
        // Debug.Log(this.GetColor() +" Color sucessfully changed");

        // Set the colorfullness to true
>>>>>>> NightMasking
        is_colorful = true;
    }
}
