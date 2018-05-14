using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour {

    // Holds the player object
    public GameObject player;

    // Holds the offset between camera and player
    private Vector3 offset;

	// Use this for initialization
	void Start()
    {
        // Call method CheckForPlayer
        CheckForPlayer();

        // Save camera z position
        float cameraZ = transform.position.z;

        // Save the position of the player (only x and y)
        Vector2 positionPlayer = (Vector2)player.transform.position;

        // Calculate the new CameraPosition (x and y of the player)
        Vector3 newCameraPosition = positionPlayer;

        // Replace the z-position of the new CameraPosition with the saved camera z-positon
        newCameraPosition.z = cameraZ;

        // Set the calculated camera position to the position of this gameObject
        transform.position = newCameraPosition;

        // Calculate offset => Position camera - Position player
        offset = transform.position - player.transform.position;
        
	}
	
	// Update is called after all other calculation are finisihed
	void LateUpdate ()
    {
        // Change position
        transform.position = player.transform.position + offset;
	}

    /// <summary>
    /// This method checks for a gameobject with the tag "Player"
    /// If no such object is found, the script will be disabled
    /// </summary>
    private void CheckForPlayer()
    {
        // Search for Gameobject with Tag "Player" and save the result in variable player
        player = GameObject.FindGameObjectWithTag("Player");

        // If no player is found
        if (!player)
        {
            //Debug.Log("No Player was found");

            // Disable the script
            enabled = false;
        }
        else
        {
           // Debug.Log("Player found");
        }
    }       
}
