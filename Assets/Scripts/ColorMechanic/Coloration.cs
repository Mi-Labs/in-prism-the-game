using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class saves the original color of the gameobject
/// -> Must be attached to every object with colorchanging mechanic
/// </summary>
public class Coloration : MonoBehaviour {

    // Holds color to colorize grayscale GO
    public Color origincolor;

    // Holds boolean (if true -> color should be applied to GO)
    private bool is_colorful;

	// Use this for initialization
	void Start ()
    {
        is_colorful = false;	
	}

    // Update is called once per frame
    void Update() { }

    public Color GetColor()
    {
        return origincolor;
    }




    public bool GetIsColorful()
    {
        return is_colorful;
    }

    /// <summary>
    /// If this method is called, the GameObject changes to the saved color
    /// </summary>
    public void ActivateColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = this.GetColor();
     //   Debug.Log(this.GetColor() +" Color sucessfully changed");
        is_colorful = true;
    }
}
