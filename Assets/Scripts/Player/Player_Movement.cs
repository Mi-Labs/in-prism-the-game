using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Movement : MonoBehaviour {

    /* Variables */

    //Rigidbody Player-Object
    private Rigidbody2D rgb2D;

    //Jump-Strength
    public float jumppower;

    //Jump factor
    private float jumpfactor;

    // Acceleration for movement
    public float acceleration = 1.5f;

    // Factor for boost power up
    public float boostfactor;




    // Constants

    // Constant boost factor
    private const float m_standardboostfactor = 1.0f;

    // Constant jump factor
    private const float m_standardjumpfactor = 1.0f;

    private bool m_canJump;

    /* Methods */

    // Use this for initialization
    void Start () {

        //Initialize Rigidbody of Player
        rgb2D = GetComponent<Rigidbody2D>();

        // Set the boostfactor on standard
        boostfactor = m_standardboostfactor;

        // Set the jumpfactor on standard
        jumpfactor = m_standardjumpfactor;

        // Initialize m_canJump
        m_canJump = false;
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
        // If there is no y-velocity ...
        if(m_canJump)
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
        boostfactor = m_standardboostfactor;

        //Debug.Log("Boost is on standard value");
    }

    /// <summary>
    /// This method sets the jumpfactor to standard (1x)
    /// </summary>
    public void SetJumpFactorToStandard()
    {
        // Set the jumpfactor to standard
        jumpfactor = m_standardjumpfactor;

        //Debug.Log("Jump is on standard value");
    }

    /// <summary>
    /// Is called every frame
    /// </summary>
    private void Update()
    {
        // Get actual velocity of the player on y-axis
        float velocityY = rgb2D.velocity.y;

        velocityY = Mathf.Abs(velocityY);
        
        // If the velocity of the player is between -0.1f and 0.1f, the player can jump
        m_canJump = (velocityY < 0.1f) ? true : false;
    }

    public void SetJumpFactor(float _factor)
    {
        jumpfactor = _factor;
    }
}
