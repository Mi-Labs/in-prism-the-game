using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This script should be attached to the player
///  When active, it should activate every Coloration Script on every GameObject
/// </summary>
public class Player_ColorEffect : MonoBehaviour {
    

    [Range(0.1f,2.0f)]
    public float m_CastRadius;

    /* Methods */



    /// <summary>
    ///  This method is called, if the player collids with an GameObject
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        // Find all objects in the give radius
        Collider2D[] hits = Physics2D.OverlapCircleAll((Vector2) _collision.collider.transform.position, m_CastRadius);

        // For every found object
        foreach (Collider2D hit in hits)
        {
            // Get Coloration script attachted on the collison partner
            Coloration coleration = hit.gameObject.GetComponent<Coloration>();

            // If there is a Coloration script ...
            if (coleration != null)
            {
                // Activate the coloration
                coleration.ActivateColor();
            }
        }

    }
}
