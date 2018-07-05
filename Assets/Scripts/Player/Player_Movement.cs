using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Movement : MonoBehaviour {

    /* Variables */

    // Acceleration for movement
    [Range(1,5)]
    public float m_acceleration;

    // Factor for boost power up
    public float boostfactor;

    [Range(1,10)]
    public float m_fallMultiplier;

    //Rigidbody Player-Object
    private Rigidbody2D rgb2D;

    //Jump-Strength
    public float jumppower;

    //Jump factor
    private float jumpfactor;



    private LayerMask m_undergroundLayer = 1 << 8;

    private float m_circleRadius;

    private bool m_canJump;


    // Constants

    // Constant boost factor
    private const float k_standardboostfactor = 1.0f;

    // Constant jump factor
    private const float k_standardjumpfactor = 1.0f;



    /* Methods */

    // Use this for initialization
    void Start () {

        //Initialize fields
        rgb2D = GetComponent<Rigidbody2D>();
        boostfactor = k_standardboostfactor;
        jumpfactor = k_standardjumpfactor;
        m_canJump = false;
        m_acceleration = 1.5f;
        m_fallMultiplier = 3.0f;
        m_circleRadius = GetComponent<CircleCollider2D>().radius + 0.1f;
	}
	
    /// <summary>
    /// This function moves the player horizontally
    /// </summary>
    /// <param name="direction">This param decides, if the movment is to the left (-1) or to the right(1)</param>
    public void MovePlayer(float _direction)
    {
        //Create movementVector2
        Vector2 movement = new Vector2(_direction*m_acceleration*boostfactor, 0);

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
        boostfactor = k_standardboostfactor;

        //Debug.Log("Boost is on standard value");
    }

    /// <summary>
    /// This method sets the jumpfactor to standard (1x)
    /// </summary>
    public void SetJumpFactorToStandard()
    {
        // Set the jumpfactor to standard
        jumpfactor = k_standardjumpfactor;

        //Debug.Log("Jump is on standard value");
    }

    /// <summary>
    /// Is called every frame
    /// </summary>
    private void Update()
    {
        m_canJump = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, m_circleRadius, m_undergroundLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
         //   Debug.Log(colliders[i].gameObject.name);

            if (colliders[i].gameObject != gameObject)
            {
           //     Debug.Log("Player can jump");
                m_canJump = true;
            }
        }
        // If the player is falling, add some extra force
        if(rgb2D.velocity.y < 0)
        {
            rgb2D.velocity += Vector2.up * Physics2D.gravity.y * (m_fallMultiplier - 1) * Time.deltaTime;
        }
    }


    public void SetJumpFactor(float _factor)
    {
        jumpfactor = _factor;
    }
}
