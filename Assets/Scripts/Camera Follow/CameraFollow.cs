using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour {

    public GameObject player;

    //
    private Vector3 offset;

	// Use this for initialization
	void Start()
    {
        // Call method CheckForPlayer
        CheckForPlayer();

        // Set Camera to Position
        float cameraZ = transform.position.z;

        Vector2 positionPlayer = (Vector2)player.transform.position;
        Vector3 newCameraPosition = positionPlayer;
        newCameraPosition.z = cameraZ;

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
            Debug.Log("No Player was found");
            // Disable the script
            enabled = false;
        }
        else
        {
            Debug.Log("Player found");
        }
    }
        
}
