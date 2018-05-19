using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    /* Variables */

    // Holds the damage for one collision with player
    public int m_objectdamage; 



    /* Methods */

    /// <summary>
    /// This method is called, when a collision with the GameObject attached to this script happened
    /// </summary>
    /// <param name="collision">The collision which is caused</param>
    public void OnCollisionEnter2D(Collision2D _collision)
    {
         // Debug.Log("Collision Found");

        // Get the gameObject which is attached to this collision  
        GameObject hit = _collision.gameObject;

        // If the other collision object is the player - do this script
        if(hit.tag.Equals("Player"))
        {

            // Debug.Log("Player hit me");

            //Get the maximum lifepoints for calculation
            int maxlife = hit.GetComponent<HealthPlayer>().GetMaxLifePoints();

            // Debug.Log(m_objectdamage + "ObjDmg");

            //  Debug.Log(maxlife + "maxlife");

            // Calculate the damage
            float damage = ((float)m_objectdamage / (float)maxlife)*100.0f;

            // Debug.Log(damage);

            // Save the damage as Integer
            int outdamage = Mathf.RoundToInt(damage);
            
            // Call damage script to decrease lifepoints with the calculated damage
            hit.GetComponent<HealthPlayer>().DecreaseLife(outdamage);

            // Debug.Log("Decrease with outdamage: " + outdamage);

            //To Do : Visual Warning if player get damage
        }
    }
}
