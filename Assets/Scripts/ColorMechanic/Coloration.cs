using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class saves the original color of the GO
/// -> Must be attached to every object with colorchanging mechanic
/// </summary>
public class Coloration : MonoBehaviour {


    /* Fields */

    // Holds color to colorize grayscale GO
    public Color m_origincolor;

    // Holds boolean (if true -> color should be applied to GO)
    private bool m_IsColorful;

    // private Vector2 m_RaycastDirectionY;


    /* Methods */

    void Start ()
    {
        m_IsColorful = false;

        //   m_RaycastDirectionY = new Vector2(0.0f, 1.0f);
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
    /// If this method is called, the GO changes to the saved color
    /// </summary>
    public void ActivateColor()
    {
        // RaycastHit2D[] hits = FindColorationObjects(m_RaycastDirectionY);

        // foreach (RaycastHit2D hit in hits)
        // {
        //    hit.collider.gameObject.GetComponent<SpriteRenderer>().color = this.GetColor();
        // }

        // Change the color of this GameObjects SpriteRenderer to the assigned color
        this.gameObject.GetComponent<SpriteRenderer>().color = this.GetColor();

        // Set the colorfulness to true
        m_IsColorful = true;
    }


    /// <summary>
    /// This method searches for all objects in a given direction and returns them
    /// </summary>
    /// <param name="_direction">Direction, in which objects should be searched</param>
    /// <returns>Array with all RaycastHits2D (All found objects)</returns>
    private RaycastHit2D[] FindColorationObjects(Vector2 _direction)
    {
        RaycastHit2D hit = FindObjectInDirection(this.transform.position,_direction);

        int objectsFound = 0;

        while(hit.collider != null)
        {
            hit = FindObjectInDirection(hit.collider.gameObject.transform.position, _direction);
            objectsFound++;
        }

        return Physics2D.RaycastAll(transform.position, _direction, (float)objectsFound * 1.0f);
    }

    /// <summary>
    /// This method searches for the next object in a given direction from a given position
    /// </summary>
    /// <param name="_position">Startpoint of search</param>
    /// <param name="_direction">Direction of search</param>
    /// <returns>Found object</returns>
    private RaycastHit2D FindObjectInDirection(Vector2 _position, Vector2 _direction)
    {
        return Physics2D.Raycast(_position, _direction, 1.0f);
    }
}
