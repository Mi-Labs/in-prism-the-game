using UnityEngine;
using UnityEngine.UI;

public class Player_Control : MonoBehaviour {

    /* Variables */

    public bool m_PlayerIsSelectable;
    public static Player_Control Instance;
    public bool m_CanJump;

    private Player_Movement movescript;
    [SerializeField]
    private static MenuSwitching m_MenuScript = null;
    private bool m_LeftActive;
    private bool m_RightActive;
    private bool m_JumpActive;
    private bool m_Break;
    //If trigger for menu is activated -> true
    private bool menu_trigger;
    // private World_Config m_config;

    /* Methods */
    // Use this for initialization
    void Start ()
    {
        // Initialize Player_Movement script
        movescript = GetComponent<Player_Movement>();

        // m_config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();
        m_CanJump = false;
        m_Break = false;
        AddPowerUpMenu();  
	}

    private void Awake()
    {
        // Add Listener for SwipeDetector
        // SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
        Instance = this;
    }

    void OnCollisionEnter(Collision hit) {
        if (hit.gameObject.layer == LayerMask.NameToLayer("Underground"))
        {
            Debug.Log("touch ground");
            m_CanJump = true;
        }
    }

    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.layer == LayerMask.NameToLayer("Underground"))
        {
            Debug.Log("leave ground");
            m_CanJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        int horizontal = 0;
        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        switch (horizontal)
        {
            case 1:
                m_RightActive = true;
                break;

            case -1:
                m_LeftActive = true;
                break;

            case 0:
                m_RightActive = false;
                m_LeftActive = false;
                break;

            default:
                Debug.Log("Unknown horizontal Input");
                break;
        }

        m_JumpActive = Input.GetKeyDown(KeyCode.Space);
        m_Break = false;
        m_Break = Input.GetKeyDown(KeyCode.DownArrow);

        if(m_MenuScript != null)
        {
            menu_trigger = Input.GetKeyDown(KeyCode.E);
        }
    
    }


    private void FixedUpdate()
    {
        if (!m_Break)
        {
            movescript.rgb2D.constraints = RigidbodyConstraints2D.None;
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
        }
        else{
            movescript.rgb2D.velocity = Vector2.zero;
            movescript.rgb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("Breaking");
        }
        if (m_JumpActive)
        {
            // Jump
            // Debug.Log("enter jump");
            movescript.JumpPlayer();
            m_JumpActive = false;
        }
        
        if (menu_trigger)
        {
            // Toggle PowerUpMenu
            m_MenuScript.ToggleMenu();
            menu_trigger = false;
        }
        Text text = GameObject.Find("LTextHead").GetComponent<Text>();
        text.text = movescript.rgb2D.velocity.ToString();
        CapSpeed();
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
            Debug.Log("Hit something "+ hit.collider.gameObject.name);

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
  
    }


    /// <summary>
    /// This method changes the selectability of the player
    /// </summary>
    /// <param name="_newStatus">True, if player can be touched</param>
    public void MakePlayerSelectable(bool _newStatus)
    {
        m_PlayerIsSelectable = _newStatus;
    }

    public void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Enter trigger");
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = other.transform;
            Debug.Log("Enter platform");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Platform")
        {
            transform.parent = null;
            Debug.Log("Leave platform");
        }
    }

    public void CapSpeed(){
        int len = (int)movescript.vlen(movescript.rgb2D.velocity);
        int maxSpeed = 10;
        int reduceCounter = 2;
        if (len > maxSpeed) {
            Vector2 force = movescript.rgb2D.velocity.normalized;
            float fx = force.x * (len - reduceCounter);
            float fy = force.y * (len - reduceCounter);
            force.x = fx;
            force.y = fy;
            force.x *= -1;
            force.y *= -1;
            movescript.rgb2D.AddForce(force);
        }
    }
}
