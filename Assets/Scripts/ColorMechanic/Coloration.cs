using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class saves the original color of the game object
/// -> Must be attached to every object with colorchanging mechanic
/// </summary>
public class Coloration : MonoBehaviour {


    /* Variables */

    // Holds color to colorize grayscale GO
    public Color m_origincolor;

    // Holds boolean (if true -> color should be applied to GO)
    private bool m_IsColorful;

    private Vector2 m_RaycastDirectionY;


    /* Methods */

    // Use this for initialization
    void Start ()
    {
        m_IsColorful = false;

        m_RaycastDirectionY = new Vector2(0.0f, 1.0f);

	}

    /// <summary>
    /// This method returns the color that is saved in this script
    /// </summary>
    /// <returns>The original color for this object</returns>
    public Color GetColor()
    {
        return m_origincolor;
    }
    
    /// <summary>
    ///  This method gets the status of the colorfulness of the object
    /// </summary>
    /// <returns>The status of the colorfulness</returns>
    public bool GetIsColorful()
    {
        return m_IsColorful;
    }

    /// <summary>
    /// If this method is called, the GameObject changes to the saved color
    /// </summary>
    public void ActivateColor()
    {
        //RaycastHit2D[] hits = FindColorationObjects(m_RaycastDirectionY);

        //foreach (RaycastHit2D hit in hits)
        //{
        //    hit.collider.gameObject.GetComponent<SpriteRenderer>().color = this.GetColor();
        //}

        // Change the color of this GameObjects SpriteRenderer to the assigned color
        this.gameObject.GetComponent<SpriteRenderer>().color = this.GetColor();

        // Debug.Log(this.GetColor() +" Color sucessfully changed");

        // Set the colorfulness to true
        m_IsColorful = true;

        
    }

    private RaycastHit2D[] FindColorationObjects(Vector2 _direction)
    {
        RaycastHit2D hit = FindObjectBelow(this.transform.position,_direction);
        float objectsBelow = 0.0f;

        while(hit.collider != null)
        {
            hit = FindObjectBelow(hit.collider.gameObject.transform.position, _direction);
            objectsBelow += 1.0f;
        }

        return Physics2D.RaycastAll(transform.position, _direction, objectsBelow * 1.0f);

    }

    private RaycastHit2D FindObjectBelow(Vector2 _position, Vector2 _direction)
    {
        
        return Physics2D.Raycast(_position, _direction, 1.0f);
    }
}
