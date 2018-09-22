using System;
using System.Collections.Generic;
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



    /* Methods */

    // Use this for initialization
    void Start ()
    {
        // Initialize Player_Movement script
        movescript = GetComponent<Player_Movement>();

        AddPowerUpMenu();

       
	}

    private void Awake()
    {
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
        

       
            
    #elif UNITY_IOS || UNITY_ANDROID

        // Touch(es) was found
        if (Input.touchCount > 0)
        {
            //Do this for every touch found
            for (int i = 0; i < Input.touchCount; i++)
            {

                Debug.Log("Touch erkannt");

                // Save touch in mytouch
                Touch mytouch = Input.GetTouch(i);

                // Save position of touch in Vector2 curpos
                Vector2 curpos = mytouch.position;       

                    switch(mytouch.phase)
                    {
                      case TouchPhase.Began:
                            if (curpos.x < (Screen.width / 6))
                            {
                                Debug.Log("Touch left started");
                                m_LeftActive = true;
                            }

                            else if(curpos.x > (Screen.width - Screen.width / 6))
                            {
                                Debug.Log("Touch right started");
                                m_RightActive = true;
                            }
         
                            if(HasPlayerBeenTouched(mytouch))
                            {
                            menu_trigger = true;
                            }
    
                                                     
                            break;

                      case TouchPhase.Ended:
                                              
                            Debug.Log("Touch ended");
                            m_LeftActive = false;
                            m_RightActive = false;
                           
                        break;
                    }
                
            }

        }
    #endif
    
    }

    private void SwipeDetector_OnSwipe(SwipeDetector.SwipeData data)
    {
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
            movescript.MovePlayer(-1.0f);
        }

        if (m_RightActive)
        {
            movescript.MovePlayer(1.0f);
        }
        if (m_JumpActive)
        {
            movescript.JumpPlayer();
            m_JumpActive = false;
        }
        //if the powerupmenu_trigger is active -> toggle the screen
        if (menu_trigger)
        {
            m_MenuScript.ToggleMenu();
            menu_trigger = false;
        }

    } 
    
    public RaycastHit2D GetTouchHit(Touch _mytouch)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(_mytouch.position);

        Debug.Log(worldPoint);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.down);
        return hit;
    }

    private bool HasPlayerBeenTouched(Touch _mytouch)
    {
        RaycastHit2D hit = GetTouchHit(_mytouch);

        if (hit.collider != null)
        {
            Debug.Log("Hit something "+ hit.collider.gameObject.name);
            if (hit.collider.tag =="Player")
            {
                Debug.Log("Player was touched");
                return true;

            }
        }
        return false;
    }

    public void AddPowerUpMenu()
    {
        m_MenuScript = GameObject.FindGameObjectWithTag("PowerUpMenu").GetComponent<MenuSwitching>();
        if(m_MenuScript == null)
        {
            Debug.LogError("PowerUp_Menu still not found");
        }
    }

}
