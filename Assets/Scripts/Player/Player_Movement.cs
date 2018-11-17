using UnityEngine;


public class Player_Movement : MonoBehaviour {

    /* Variables */

    // Acceleration for movement
    [Range(1,5)]
    public float m_acceleration;

    // Factor for boost power up
    public float boostfactor;
    [Space]
    [Header("Jump Attributs")]
    //Jump-Strength
    public float m_JumpPowerMobile;
    //[Range(0, 1)]
    public float m_JumpPowerDesk;
    //public float m_JumpThresholdX; 

    [Space]
    [Header("Fall Multiplier (Experimental)")]
    [Range(1, 10)]
    public float m_fallMultiplier;

    public bool m_ActivateFallMultiplier;

    //Rigidbody Player-Object
    private Rigidbody2D rgb2D;


    //Jump factor
    private float jumpfactor;


    private bool m_canJump;


    // Constants

    // Constant boost factor
    private const float k_standardboostfactor = 1.0f;

    // Constant jump factor
    private const float k_standardjumpfactor = 1.0f;


    public LayerMask m_DetectTheseLayers;



    /* Methods */

    // Use this for initialization
    void Start () {

        //Initialize fields
        rgb2D = GetComponent<Rigidbody2D>();
        boostfactor = k_standardboostfactor;
        jumpfactor = k_standardjumpfactor;
        m_canJump = false;
        m_fallMultiplier = 3.0f;
	}
	
    /// <summary>
    /// This function moves the player horizontally
    /// </summary>
    /// <param name="direction">This param decides, if the movment is to the left (-1) or to the right(1)</param>
    public void MovePlayer(float _direction)
    {
        //Create movementVector2
        Vector2 movement = new Vector2(_direction*m_acceleration*boostfactor*Time.deltaTime*100, 0);
      
        //Add movement to Rigidbody
        rgb2D.AddForce(movement);

    }

    /// <summary>
    /// This function makes the player jump
    /// </summary>
    public void JumpPlayer()
    {
        if(m_canJump)
        {
        #if UNITY_IOS || UNITY_ANDROID
            //Create movementVector2
            Vector2 movement = new Vector2(0f, m_JumpPowerMobile * jumpfactor*Time.deltaTime*1000);
        #elif UNITY_STANDALONE || UNITY_WEBGL
            //Create movementVector2
            Vector2 movement = new Vector2(0f, m_JumpPowerDesk * jumpfactor*Time.deltaTime*1000);
        #endif
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

       
    }

    /// <summary>
    /// Is called every frame
    /// </summary>
    private void FixedUpdate()
    {
        m_canJump = false;
        // Cast Box under player
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position, new Vector2(0.01f,0.01f), 0.0f, Vector2.down,0.5f);

        // If the hit isn't the player and not null 
        if (raycastHit.collider != null && !raycastHit.collider.gameObject.tag.Equals("Player"))
        {
            m_canJump = true;
        }
        else
        {
            m_canJump = false;
        }

        // Experimental Fall Multiplier
        if(m_ActivateFallMultiplier)
        {
            // If the player is falling, add some extra force
            if (rgb2D.velocity.y < 0)
            {
                rgb2D.velocity += Vector2.up * Physics2D.gravity.y * (m_fallMultiplier - 1) * Time.deltaTime;
            }
        }
    }


    public void SetJumpFactor(float _factor)
    {
        jumpfactor = _factor;
    }

}
