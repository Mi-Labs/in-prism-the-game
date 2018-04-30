using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    // Holds the damage for one collission with player
    public int objectdamage; 

    /// <summary>
    /// This method is called, when a collison with the gameObject attachted to this script happend
    /// </summary>
    /// <param name="collision">The collission which is caused</param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Collison Found");

        // Get the gameObject which is attached to this collission  
        GameObject hit = collision.gameObject;

        // If the other collission object is the player - do this script
        if(hit.tag == "Player")
        {

            //Debug.Log("Player hit me");

            //Get the maximum lifepoints for caluclation
            int maxlife = hit.GetComponent<HealthPlayer>().GetMaxLifePoints();

            //Debug.Log(objectdamage + "ObjDmg");

            //Debug.Log(maxlife + "maxlife");

            // Calculate the damage
            float damage = ((float)objectdamage / (float)maxlife)*100.0f;

            //Debug.Log(damage);

            // Save the damage as Integer
            int outdamage = Mathf.RoundToInt(damage);
            
            // Call damage script to decrease lifepoints with the calculated damage
            hit.GetComponent<HealthPlayer>().DecreaseLife(outdamage);

            //Debug.Log("Decrease with outdamage: " + outdamage);

            //To Do : Visual Warning if player get damage
        }
    }
}
