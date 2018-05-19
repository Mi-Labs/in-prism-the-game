using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLight : MonoBehaviour {

	// Use this for initializatio

    public GameObject pictureText;


    /* Methods */

    /// <summary>
    /// This method is called, if the player causes the trigger.
    /// It should be used to signalize the end of the level
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Loading Text");
        // Clone the Prefab at the position of the this gameObject
        //Spritemask Aktivate if PowerUp is Clickt
        Instantiate(pictureText, this.transform.position, Quaternion.identity, transform);
    }
}
