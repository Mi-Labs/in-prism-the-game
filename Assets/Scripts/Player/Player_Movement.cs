using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Movement : MonoBehaviour {

    /* Variables */

    //Rigidbody Player-Object
    private Rigidbody2D rgb2D;

    //Jump-Strength
    public float jumppower;

    public float jumpfactor;

    // Acceleration for movement
    public float acceleration = 1.5f;

    // Factor for boost powerup
    public float boostfactor;

    // If the player has an collision with something-> true, else false
    private bool isGrounded;


    // Constants

    // Constant boost factor
    private const float standardboostfactor = 1.0f;

    // Constant jump factor
    private const float standardjumpfactor = 1.0f;


    /* Methods */

    // Use this for initialization
    void Start () {

        //Initalize Rigidbody of Player
        rgb2D = GetComponent<Rigidbody2D>();

        //Set the boostfactor on standard
        boostfactor = standardboostfactor;

        //Set the jumpfactor on standard
        jumpfactor = standardjumpfactor;
	}
	
    /// <summary>
    /// This function moves the player horizontally
    /// </summary>
    /// <param name="direction">This param decides, if the movment is to the left (-1) or to the right(1)</param>
    public void MovePlayer(float direction)
    {
        //Create movementVector2
        Vector2 movement = new Vector2(direction*acceleration*boostfactor, 0);

        //Add movement to Rigidbody
        rgb2D.AddForce(movement);

    }

    /// <summary>
    /// This function makes the player jump
    /// </summary>
    public void JumpPlayer()
    {
        if(isGrounded)
        {
            //Create movementVector2
            Vector2 movement = new Vector2(0f, jumppower * jumpfactor);

            //Add movement to rgb2D
            rgb2D.AddForce(movement);
        }
        
    }

    /// <summary>
    /// This method sets the boostfactor to standard (1x)
    /// </summary>
    public void SetBoostSpeedToStandard()
    {
        // Set the boostfactor to standard
        boostfactor = standardboostfactor;

        //Debug.Log("Boost is on standard value");
    }

    /// <summary>
    /// This method sets the jumpfactor to standard (1x)
    /// </summary>
    public void SetJumpFactorToStandard()
    {
        // Set the jumpfactor to standard
        jumpfactor = standardjumpfactor;

        //Debug.Log("Jump is on standard value");
    }

    /// <summary>
    ///  This method is called, when the parent GameObject collids with another object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }


    /// <summary>
    /// This method is called, when the collision of the parent GameObject and another Object is over
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
