using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayer : MonoBehaviour {

    // Holds the PreFab for the player
    public GameObject player;


    /// <summary>
    ///  Add a clone of the player at the position of this gameobject
    /// </summary>
    void Start ()
    {
        Instantiate(player, this.transform.position, Quaternion.identity, this.transform);
	}
}
