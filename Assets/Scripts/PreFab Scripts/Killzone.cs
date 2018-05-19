using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script manages the proper kill zone behavior
/// Kill everything that enters it
/// </summary>
public class Killzone : MonoBehaviour
{
    /* Variables */

    // Holds the damage that the kill zone should deal
    public int m_killzone_damage;



    /* Methods */

    /// <summary>
    /// Is called, when the kill zone is activated
    /// </summary>
    private void Start()
    {
       
        // Find Player, look for maximal health, multiply it with 2 -> sure death of player
        m_killzone_damage = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPlayer>().GetMaxLifePoints() * 2;
    }

    /// <summary>
    ///  This method is called, when a trigger on this game object is caused
    /// </summary>
    /// <param name="_collision">The other collider</param>
    private void OnTriggerEnter2D(Collider2D _collider)
    {
        // Get the GameObject that is attached to the other collider
        GameObject hit = _collider.gameObject;

        // If the other GameObject has the "Player"-Tag ...
        if(hit.tag.Equals("Player"))
        {
            // decrease it's life with the kill zone damage
            hit.GetComponent<HealthPlayer>().DecreaseLife(m_killzone_damage);
        }

        // Any other object should be destroyed
        else
        {
            Destroy(hit);
        }
    }
}
