using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour {
    
    //
    private GameObject player;

    private Player_Movement movescript;

    private bool left_active;

    private bool right_active;

    private bool jump_active;

    private bool powermenu_active;


	// Use this for initialization
	void Start () {
        movescript = GetComponent<Player_Movement>();
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
                right_active = true;
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

        powermenu_active = Input.GetKeyDown(KeyCode.E);

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

                // Save endposition of touch in Vector endpos
                Vector2 endpos = mytouch.deltaPosition;

                //Calculate Touch-Speed
                float touchspeed = endpos.magnitude / mytouch.deltaTime;

                Debug.Log("Touch erkannt" + mytouch.fingerId);

                Debug.Log(touchspeed);
                

                    switch(mytouch.phase)
                    {
                      case TouchPhase.Began:
                            if (curpos.x < (Screen.width / 6))
                            {
                                Debug.Log("Touch left started");
                                left_active = true;
                            }

                            else if(curpos.x > (Screen.width - Screen.width / 6))
                            {
                                Debug.Log("Touch right started");
                            right_active = true;
                            }

                            else if(touchspeed > 800)
                            {
                            jump_active = true;
                            }
    
                                                     
                            break;

                      case TouchPhase.Ended:
                                              
                            Debug.Log("Touch ended");
                            left_active = false;
                            right_active = false;
                            jump_active = false;
                        break;

                      default:

                            Debug.Log("Error, no regular TouchPhase");
                            break;
                    }

            }
        }
    #endif
    
    }

    /// <summary>
    /// Does physics after every Update
    /// </summary>
    private void FixedUpdate()
    {
        
        if(left_active)
        {
            movescript.MovePlayer(-1f);
        }

        if (right_active)
        {
            movescript.MovePlayer(1f);
        }
        if (jump_active)
        {
            movescript.JumpPlayer();
        }
        if(powermenu_active)
        {
            //powerupscript;
        }
    }

        
}
