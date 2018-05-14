using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class Player_Movement : MonoBehaviour {

=======

public class Player_Movement : MonoBehaviour {

    /* Variables */

>>>>>>> NightMasking
    //Rigidbody Player-Object
    private Rigidbody2D rgb2D;

    //Jump-Strength
    public float jumppower;

    public float jumpfactor;

    //acceleration for movement
    public float acceleration = 1.5f;

    //Factor for boost powerup
    public float boostfactor;

<<<<<<< HEAD
    /*
     *  If true     -> Player has contact with another gameObject
     *  If false    -> Player has no contact with another gameObject
     */
    private bool is_Grounded;
=======
>>>>>>> NightMasking

    // Constants

    // Constant boost factor
    private const float standardboostfactor = 1.0f;

    // Constant jump factor
    private const float standardjumpfactor = 1.0f;


<<<<<<< HEAD
=======
    /* Methods */

>>>>>>> NightMasking
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
<<<<<<< HEAD
        // If there is a collision with another gameObject, Jump is available
       if(is_Grounded)
        {
            //Create movementVector2
            Vector2 movement = new Vector2(0f, jumppower * jumpfactor);

            //Add movement to rgb2D
            rgb2D.AddForce(movement);
        }

=======
        //Create movementVector2
        Vector2 movement = new Vector2(0f, jumppower*jumpfactor);

        //Add movement to rgb2D
        rgb2D.AddForce(movement);
>>>>>>> NightMasking
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

<<<<<<< HEAD

=======
>>>>>>> NightMasking
    /// <summary>
    /// This method sets the jumpfactor to standard (1x)
    /// </summary>
    public void SetJumpFactorToStandard()
    {
        // Set the jumpfactor to standard
        jumpfactor = standardjumpfactor;

        //Debug.Log("Jump is on standard value");
    }
<<<<<<< HEAD

    /// <summary>
    /// This mehtod is called, if the player enter a collison
    /// </summary>
    /// <param name="collision">Collision with another rigidbody</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        is_Grounded = true;
    }

    /// <summary>
    /// This method is called, if the player leave the collision
    /// </summary>
    /// <param name="collision">Collision with another rigidbody</param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        is_Grounded = false;
    }
=======
>>>>>>> NightMasking
}
