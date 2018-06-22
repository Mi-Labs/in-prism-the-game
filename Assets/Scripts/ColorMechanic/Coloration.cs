using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class saves the original color of the GO
/// -> Must be attached to every object with colorchanging mechanic
/// </summary>
public class Coloration : MonoBehaviour {


    /* Fields */

    // Holds boolean (if true -> color should be applied to GO)
    private bool m_IsColorful;

    public Material m_standardMaterial;


    /* Methods */

    void Start ()
    {
        m_IsColorful = false;

        //   m_RaycastDirectionY = new Vector2(0.0f, 1.0f);

        
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

        // Change the color of this GameObjects SpriteRenderer to the assigned color
        SpriteRenderer[] spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();

        foreach(SpriteRenderer renderer in spriteRenderers)
        {
            renderer.material = m_standardMaterial;
        }

        // Set the colorfulness to true
        m_IsColorful = true;
    }

}
