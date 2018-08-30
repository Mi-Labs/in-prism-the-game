using UnityEngine;

public class AddTopping : MonoBehaviour {

    /* Fields */

    // Holds the prefab for the topping
    public GameObject m_topping;

    // Hold the length and direction of the raycast
    public float m_castLength;

    [Space(20)]
    [Header("Debug Mode")]
    public bool m_DebugMode;
    public float m_DebugDuration;


    private Vector2 m_castDirection;

    // Holds the layer for checking
    private LayerMask m_undergroundMask;


    /* Methods */

   /// <summary>
   /// This method is called before Start()
   /// </summary>
    void Awake ()
    {
        // Init cast direction and length
        m_castDirection = Vector2.up;        
       // m_castLength = 0.6f;

        // Set LayerMask to Layer 8 -> Underground
        m_undergroundMask = 1 << 8;       
	}

    /// <summary>
    /// This method generates a topping, if there is nothing above the GO
    /// </summary>
    public void GenerateTopping()
    {
        if(m_DebugMode)
        {
            Vector3 direction = transform.position + new Vector3(0.0f, m_castLength, 0.0f);
            Debug.DrawLine(transform.position,direction , Color.white, m_DebugDuration);
        }

        bool thingAbove = CheckIfSomethingAbove();

        // If there isn't anything above, create the topping
        if (!thingAbove)
        {
            Instantiate(m_topping, this.transform.position, Quaternion.identity, this.transform);
        }
    }

    /// <summary>
    /// This method checks, if a GO on the given layer is above the current GO
    /// </summary>
    /// <returns>True, if something is above</returns>
    private bool CheckIfSomethingAbove()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, m_castDirection, m_castLength, m_undergroundMask);

        // Returns true if there was a object above
        return (hit.collider != null) ? true : false;
    }
}
