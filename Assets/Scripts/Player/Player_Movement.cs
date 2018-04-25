using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    //Rigidbody Player-Object
    private Rigidbody2D rgb2D;

    //Jump-Strength
    public float jumppower;

    public float jumpfactor;

    //acceleration for movement
    public float acceleration = 1.5f;

    //Factor for boost powerup
    public float boostfactor;


    // Constants

    // Constant boost factor
    private const float standardboostfactor = 1.0f;

    // Constant jump factor
    private const float standardjumpfactor = 1.0f;


    // Use this for initialization
    void Start () {

        //Initalize Rigidbody of Player
        rgb2D = GetComponent<Rigidbody2D>();
        boostfactor = standardboostfactor;
        jumpfactor = standardjumpfactor;
	}
	
	// Update is called once per frame
	void Update () {
		
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
        //Create movementVector2
        Vector2 movement = new Vector2(0f, jumppower*jumpfactor);

        //Add movement to rgb2D
        rgb2D.AddForce(movement);
    }

    /// <summary>
    /// This method sets the boostfactor to standard (1x)
    /// </summary>
    public void SetBoostSpeedToStandard()
    {
        boostfactor = standardboostfactor;
        Debug.Log("Boost is on standard value");
    }


    /// <summary>
    /// This method sets the jumpfactor to standard (1x)
    /// </summary>
    public void SetJumpFactorToStandard()
    {
        jumpfactor = standardjumpfactor;
        Debug.Log("Jump is on standard value");
    }
}
