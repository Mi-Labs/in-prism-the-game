using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTopping : MonoBehaviour {

    public GameObject m_topping;

    private Vector2 m_castDirection;

    private float m_castLength;

    private LayerMask m_undergroundMask;

    // Use this for initialization
    void Start ()
    {
        // Set castDirection to upwards
        m_castDirection = new Vector2(0.0f, 1.0f);

        m_castLength = 0.6f;

        // Set LayerMask to Layer 8 -> Underground
        m_undergroundMask = 1 << 8;

        bool thingAbove = CheckIfSomethingAbove();

        // If there isn't anything above, create the topping
        if(!thingAbove)
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

        // Debug.DrawRay(transform.position, m_castDirection,Color.white,15);

        // Returns true if there was a object above
        return (hit.collider != null) ? true : false;
    }

}
