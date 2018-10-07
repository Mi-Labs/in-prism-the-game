using UnityEngine;

public class Player_Control : MonoBehaviour {

    /* Variables */

    private Player_Movement movescript;

    [SerializeField]
    private static MenuSwitching m_MenuScript = null;

    private bool m_LeftActive;

    private bool m_RightActive;

    private bool m_JumpActive;

    //If trigger for menu is activated -> true
    private bool menu_trigger;

    private World_Config m_config;

    /* Methods */

    // Use this for initialization
    void Start ()
    {
        // Initialize Player_Movement script
        movescript = GetComponent<Player_Movement>();

        m_config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();

        AddPowerUpMenu();  
	}

    private void Awake()
    {
        // Add Listener for SwipeDetector
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    // Update is called once per frame
    void Update()
    {

    #if UNITY_STANDALONE || UNITY_WEBGL
        int horizontal = 0;

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));

        switch (horizontal)
        {
            case 1:
                m_RightActive = true;
                break;

            case -1:
                left_active = true;
                break;

            case 0:
                right_active = false;
                left_active = false;
                break;

            default:
                Debug.Log("Unknown horizontal Input");
                break;
        }

        jump_active = Input.GetKeyDown(KeyCode.Space);

        if(m_MenuScript != null)
        {
            menu_trigger = Input.GetKeyDown(KeyCode.E);
        }
        

       
    // When build platform is IOS or Android            
    #elif UNITY_IOS || UNITY_ANDROID

        // Touch(es) was found
        if (Input.touchCount > 0)
        {
            //Do this for every touch found
            for (int i = 0; i < Input.touchCount; i++)
            {
                //  Debug.Log("Touch found");

                // Save touch in mytouch
                Touch mytouch = Input.GetTouch(i);

                // Save position of touch in Vector2 curpos
                Vector2 curpos = mytouch.position;       

                    switch(mytouch.phase)
                    {
                      case TouchPhase.Began:
                        // If the touch is in the left end of the screen (0 - 1/6)
                        if (curpos.x < (Screen.width / 6))
                        {
                            // Debug.Log("Touch left started");
                            if (m_config.m_InverseControls)
                            {
                                m_RightActive = true;
                            }
                            else
                            {
                                m_LeftActive = true;
                            }
                        }

                        // If the touch is in the right end of the screen (5/6 -1)
                        else if (curpos.x > (Screen.width - Screen.width / 6))
                        {
                            // Debug.Log("Touch right started");
                            if (m_config.m_InverseControls)
                            {
                                m_LeftActive = true;
                            }
                            else
                            {
                                m_RightActive = true;
                            }
                        }
                            
                            // If the player is touched -> activate the menu
                            if(HasPlayerBeenTouched(mytouch))
                            {
                            menu_trigger = true;
                            }
                                         
                            break;

                      case TouchPhase.Ended:
                                              
                            // Debug.Log("Touch ended");
                            m_LeftActive = false;
                            m_RightActive = false;
                           
                        break;
                    }
            }

        }
    #endif
    
    }


    /// <summary>
    ///  If there is a swipe, do this action
    /// </summary>
    /// <param name="data">The data from the swipe detector</param>
    private void SwipeDetector_OnSwipe(SwipeDetector.SwipeData data)
    {
        // If the swipe direction is up -> make a jump
        if(data.direction == SwipeDetector.SwipeDirection.Up)
        {
            m_JumpActive = true;
        }
        else
        {
            m_JumpActive = false;
        }
        
    }


    /// <summary>
    /// Does physics after every Update
    /// </summary>
    private void FixedUpdate()
    {

        if (m_LeftActive)
        {
            // Move left
            movescript.MovePlayer(-1.0f);
        }

        if (m_RightActive)
        {
            // Move right
            movescript.MovePlayer(1.0f);
        }
        if (m_JumpActive)
        {
            // Jump
            movescript.JumpPlayer();
            m_JumpActive = false;
        }
        
        if (menu_trigger)
        {
            // Toggle PowerUpMenu
            m_MenuScript.ToggleMenu();
            menu_trigger = false;
        }
    } 
    

    /// <summary>
    /// This method coverts the touch positon and does a raycast at this position
    /// </summary>
    /// <param name="_mytouch">The touch that should be converted</param>
    /// <returns>First result of the raycast at the touch position</returns>
    public RaycastHit2D GetTouchHit(Touch _mytouch)
    {
        // Convert Touchposition to world position
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(_mytouch.position);

        // Debug.Log(worldPoint);

        // Raycast at this position
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, new Vector2(0.01f,0.01f));

        // Return the result
        return hit;
    }

    /// <summary>
    /// This method checks if a touch hits the player
    /// </summary>
    /// <param name="_mytouch">The touch that should be checked</param>
    /// <returns>true, if player is touched</returns>
    private bool HasPlayerBeenTouched(Touch _mytouch)
    {
        // Raycast at the touch position
        RaycastHit2D hit = GetTouchHit(_mytouch);

        // If there is an object...
        if (hit.collider != null)
        {
            // Debug.Log("Hit something "+ hit.collider.gameObject.name);

            // If the object has the player tag...
            if (hit.collider.tag == "Player")
            {
                // Debug.Log("Player was touched");
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// This method adds the powerup menu
    /// </summary>
    public void AddPowerUpMenu()
    {
        m_MenuScript = GameObject.FindGameObjectWithTag("PowerUpMenu").GetComponent<MenuSwitching>();

        Debug.Assert(m_MenuScript == null, "PowerUp_Menu still not found");     
    }

}
