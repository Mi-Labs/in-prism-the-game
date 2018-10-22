using UnityEngine;

/// <summary>
///  This script allows the camera to follow the player
/// </summary>
public class CameraFollow : MonoBehaviour {

    /* Fields */

    // Holds the player object
    public static GameObject m_player;

    // Distance in the x axis the player can move before the camera follows.
    public float m_xMargin = 10f;

    // Distance in the y axis the player can move before the camera follows.
    public float m_yMargin = 10f;

    // How smoothly the camera catches up with it's target movement in the x axis.
    public float m_xSmooth = 8f;

    // How smoothly the camera catches up with it's target movement in the y axis.
    public float m_ySmooth = 8f;

    // Holds the level generator
    public GameObject m_levelgenerator;

    // The maximum x coordinate the camera can have.
    private float m_maxX;
    
    // The maximum y coordinate the camera can have.
    private float m_maxY;

    // The minimum x coordinate the camera can have.
    private  float m_minX; 

    // The minimum y coordinate the camera can have.
    private float m_minY;

    private bool m_LevelGenLoaded;

    private bool m_BoundsCalculated;


    /* Methods */

    // Use this for initialization
    void Start()
    {
        // Call method CheckForPlayer
        CheckForPlayer();

        // Save camera z position
        float cameraZ = transform.position.z;

        // Save the position of the player (only x and y)
        Vector2 positionPlayer = (Vector2)m_player.transform.position;

        // Calculate the new camera position (x and y of the player)
        Vector3 newCameraPosition = positionPlayer;

        // Replace the z-position of the new camera position with the saved camera z-position
        newCameraPosition.z = cameraZ;

        // Set the calculated camera position to the position of this GO
        transform.position = newCameraPosition;


        // SendLevelGen.LevelGen += SendLevelGen_LevelGen;

        // Search for the level generator object and assign it.
        //m_levelgenerator = GameObject.Find("LevelGenerator");

        m_BoundsCalculated = false;
    }

 


    // Update is called after all other calculation are finished
    void LateUpdate ()
    {
        Debug.Log(m_LevelGenLoaded+ "LvlGen");

        if(m_LevelGenLoaded && !m_BoundsCalculated)
        {
            // Calculate the camera bounds
            CalculateCameraBounds();
            // Debug.Log("Calculated CameraBounds");
        }
        else if(m_LevelGenLoaded && m_BoundsCalculated)
        {
            CheckForPlayer();
            FollowPlayer();
        }
        
	}

    //private void SendLevelGen_LevelGen(GameObject _obj)
    //{
    //    m_levelgenerator = _obj;
    //}

    /// <summary>
    ///  This method calculates the actual player position and makes the camera follow it
    /// </summary>
    public void FollowPlayer()
    {
        // Make the player coordinates the target coordinates for the new camera position
        float targetX = m_player.transform.position.x;
        float targetY = m_player.transform.position.y;

        // If the player has moved beyond the x margin 
        if (CheckXMargin())
        {
             // The targetX coordinate should be a calculated point between camera and player position
             // To avoid camera jumps, the xSmooth affects this
            targetX = Mathf.Lerp(this.transform.position.x, m_player.transform.position.x, m_xSmooth * Time.deltaTime);
        }

        if (CheckYMargin())
        {
            // The targetY coordinate should be a calculated point between camera and player position
            // To avoid camera jumps, the ySmooth affects this
            targetX = Mathf.Lerp(this.transform.position.y, m_player.transform.position.y, m_ySmooth * Time.deltaTime);
        }

        // The target coordinates shouldn't be larger than the maximum or smaller than the minimum
        // If the value is > max, then it should be the max
        // If the value is < min, then it should be the min
        // If the value is in between, the value will be returned
        targetX = Mathf.Clamp(targetX, m_minX, m_maxX);
        targetY = Mathf.Clamp(targetY, m_minY, m_maxY);

        // Set the new camera position to the calculated target , keep the z-axis value
        this.transform.position = new Vector3(targetX, targetY, this.transform.position.z);    
    }

    /// <summary>
    ///  This method checks, if the distance between the camera and the player 
    ///  along the x axis is greater then the x margin
    /// </summary>
    /// <returns>If the distance is greater than x margin, return true</returns>
    private bool CheckXMargin()
    {
        // Calculate the distance between camera and player on x-axis and compare it with x margin
        return Mathf.Abs(transform.position.x - m_player.transform.position.x) > m_xMargin;
    }


    /// <summary>
    ///  This method checks, if the distance between the camera and the player 
    ///  along the y axis is greater then the y margin
    /// </summary>
    /// <returns>If the distance is greater than y margin, return true</returns>
    private bool CheckYMargin()
    {
        // Calculate the distance between camera and player on y axis and compare it with y margin
        return Mathf.Abs(transform.position.y - m_player.transform.position.y) > m_yMargin;
    }


    /// <summary>
    /// This method checks for a GO with the tag "Player"
    /// If no such object is found, the script will be disabled
    /// </summary>
    private void CheckForPlayer()
    {
        // Search for GO with Tag "Player" and save the result in variable player
        m_player = GameObject.FindGameObjectWithTag("Player");

        // If no player is found
        if (!m_player)
        {
            // Disable the script
            Destroy(gameObject.GetComponent<CameraFollow>());
        }
    }


    /// <summary>
    /// This method calculates the area, where the camera should move
    /// </summary>
    private void CalculateCameraBounds()
    {
        // Hold the width of the level locally
        float levelmap_width = m_levelgenerator.GetComponent<Level_Generator>().levelmap.width;

        // Hold the height of the level locally
        float levelmap_heigth = m_levelgenerator.GetComponent<Level_Generator>().levelmap.height;

        // Get the extend of the camera
        float vertical_extend = GetComponent<Camera>().orthographicSize;
        float horizontal_extend = vertical_extend * Screen.width / Screen.height;

        // Calculate the maximal camera x-position 
        m_maxX = levelmap_width - horizontal_extend;

        // Calculate the maximal camera y-position
        m_maxY = levelmap_heigth - vertical_extend;

        // Init minX and minY
        m_minX = horizontal_extend;
        m_minY = vertical_extend;

        m_BoundsCalculated = true;
    }

    private void OnDestroy()
    {
       // SendLevelGen.LevelGen -= SendLevelGen_LevelGen;
    }

    public void InsertLevelGen(GameObject _Gen)
    {
        m_levelgenerator = _Gen;
        m_LevelGenLoaded = true;
       // Debug.Log("LevelGen input");
       // Debug.Log(_Gen.name);
    }
}
