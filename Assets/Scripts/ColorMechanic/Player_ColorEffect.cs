using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class Player_ColorEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {}

	
	// Update is called once per frame
	void Update () {}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Coloration>().ActivateColor();
=======
/// <summary>
///  This script should be attached to the player
///  When active, it should activate every Coloration Script on every GameObject
/// </summary>
public class Player_ColorEffect : MonoBehaviour {


    /* Methods */

    /// <summary>
    ///  This method is called, if the player collids with an GameObject
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get Coloration script attachted on the collison partner
        Coloration coleration = collision.gameObject.GetComponent<Coloration>();

        // If there is a Coloration script ...
        if(coleration != null)
        {
            // Activate the coloration
            coleration.ActivateColor();
        }
>>>>>>> NightMasking
    }
}
