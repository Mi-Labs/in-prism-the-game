using UnityEngine;
using UnityEngine.UI;
using System;

public class Player_Movement : MonoBehaviour {

    /* Variables */

    // Acceleration for movement
    [Range(1,2)]
    public float m_acceleration;
    Vector2 m_movement;
    // Factor for boost power up
    public float boostfactor;
    [Space]
    [Header("Jump Attributs")]
    //Jump-Strength
    public float m_JumpPower;


    [Space]
    [Header("Fall Multiplier (Experimental)")]
    [Range(1, 10)]
    public float m_fallMultiplier;

    public bool m_ActivateFallMultiplier;

    //Rigidbody Player-Object
    public Rigidbody2D rgb2D;


    //Jump factor
    private float jumpfactor;
    // private bool m_canJump;


    // Constants

    // Constant boost factor
    private const float k_standardboostfactor = 1.0f;

    // Constant jump factor
    private const float k_standardjumpfactor = 1.0f;
    private int jumpCount = 1;
    private int maxJumps = 2;


    /* Methods */

    // Use this for initialization
    void Start () {
        //Initialize fields
        rgb2D = GetComponent<Rigidbody2D>();
        boostfactor = k_standardboostfactor;
        jumpfactor = k_standardjumpfactor;
        m_fallMultiplier = 3.0f;
	}
	
    /// <summary>
    /// This function moves the player horizontally
    /// </summary>
    /// <param name="direction">This param decides, if the movment is to the left (-1) or to the right(1)</param>
    public void MovePlayer(float _direction)
    {
        //Create movementVector2
        int timeMult = 100;
        float physic = _direction * m_acceleration * boostfactor * Time.deltaTime * timeMult;

        Vector2 movement = new Vector2(physic, 0);
        m_movement = movement;
        rgb2D.AddForce(movement);
    }

    public float vlen(Vector2 x){
        return (float)Math.Sqrt((x.x * x.x) + (x.y * x.y));
    }

    /// <summary>
    /// This function makes the player jump
    /// </summary>
    public void JumpPlayer()
    {

        // Cast Box under player
        float hitbox = 0.5f;
        float range = 0.0f;
        RaycastHit2D raycastHitD = Physics2D.BoxCast(transform.position, new Vector2(0.1f, 0.1f), range, Vector2.down, hitbox);
        RaycastHit2D raycastHitL = Physics2D.BoxCast(transform.position, new Vector2(0.1f, 0.1f), range, Vector2.left, hitbox);
        RaycastHit2D raycastHitR = Physics2D.BoxCast(transform.position, new Vector2(0.1f, 0.1f), range, Vector2.right, hitbox);

        // !If the hit isn't the player and not null 
        bool hitD = raycastHitD.collider != null && !raycastHitD.collider.gameObject.tag.Equals("Player");
        bool hitL = raycastHitL.collider != null && !raycastHitL.collider.gameObject.tag.Equals("Player");
        bool hitR = raycastHitR.collider != null && !raycastHitR.collider.gameObject.tag.Equals("Player");

        if (jumpCount > maxJumps)
        {
            if (!(hitD || hitL || hitR))
            {
                return;
            }
            jumpCount = 1;
        }

        //Create movementVector2
        float factor = Math.Min(vlen(rgb2D.velocity), 0.5f);
        factor = Math.Max(factor, 10f);
        factor /= 8;
        int timeMult = 1000;

        float physic = m_JumpPower * jumpfactor;
        physic *= Time.deltaTime * timeMult;
        physic /= factor;

        float py = gameObject.transform.position.y;
        float px = gameObject.transform.position.x;
        float normalX = 0;
        float normalY = 0;

        if (hitD){
            normalX = raycastHitD.normal.x;
            normalY = raycastHitD.normal.y;
        }
        if (hitL){
            normalX = raycastHitD.normal.x;
            normalY = raycastHitD.normal.y;
        }
        if (hitR) {
            normalX = raycastHitD.normal.x;
            normalY = raycastHitD.normal.y;
        }
        if (jumpCount == 2) {
            Debug.Log("Second jump");
            normalY = 0.9f;
            normalX = 0;
        }
        Vector2 movement = new Vector2(normalX * physic, normalY * physic);
        rgb2D.AddForce(movement);
        jumpCount += 1;
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

       
    }

    /// <summary>
    /// Is called every frame
    /// </summary>
    private bool CanJump()
    {
        //bool m_canJump = false;
        bool m_canJump = false;
        // Cast Box under player
        float hitbox = 0.5f;
        float range = 0.0f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, new Vector2(0.1f, 0.1f), range, Vector2.down, hitbox);

        // If the hit isn't the player and not null 
        if (raycastHit.collider != null && !raycastHit.collider.gameObject.tag.Equals("Player"))
        {
            Debug.Log("can jump, keine sorge");
            m_canJump = true;
        }

        /*
        // Experimental Fall Multiplier
        if(m_ActivateFallMultiplier)
        {
            // If the player is falling, add some extra force
            if (rgb2D.velocity.y < 0)
            {
                rgb2D.velocity += Vector2.up * Physics2D.gravity.y * (m_fallMultiplier - 1) * Time.deltaTime;
            }
        }
        */

        return m_canJump;

    }


    public void SetJumpFactor(float _factor)
    {
        jumpfactor = _factor;
    }

}
