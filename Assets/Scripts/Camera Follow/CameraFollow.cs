using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
///  This script allows the camera to follow the player
/// </summary>
public class CameraFollow : MonoBehaviour {

    /* Variables */

    // Holds the player object
    public GameObject player;

    // Distance in the x axis the player can move before the camera follows.
    public float xMargin = 1f;

    // Distance in the y axis the player can move before the camera follows.
    public float yMargin = 1f;

    // How smoothly the camera catches up with it's target movement in the x axis.
    public float xSmooth = 8f;

    // How smoothly the camera catches up with it's target movement in the y axis.
    public float ySmooth = 8f;

    // Holds the level generator
    public GameObject levelgenerator;

    // The maximum x coordinate the camera can have.
    private float maxX;
    
    // The maximum y coordinate the camera can have.
    private float maxY;

    // The minimum x coordinate the camera can have.
    private float minX; 

    // The minimum y coordinate the camera can have.
    private float minY;



    /* Methods */

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

        // Search for the level generator object and assign it.
        levelgenerator = GameObject.Find("LevelGenerator");

        // Hold the width of the level locally
        float levelmap_width = levelgenerator.GetComponent<Level_Generator>().levelmap.width;

        // Hold the heigth of the level locally
        float levelmap_heigth = levelgenerator.GetComponent<Level_Generator>().levelmap.height;

        // Calculate the maximal camera x-position (max 9/10 of the level width)
        maxX = levelmap_width - (levelmap_width / 10);

        // Calculate the maximal camera y-position (max 9/10 of the level height)
        maxY = levelmap_heigth - (levelmap_heigth / 10);

        // Init minX and minY
        minX = 0.0f;
        minY = 0.0f;
    }

    // Update is called after all other calculation are finisihed
    void LateUpdate ()
    {
        FollowPlayer();   
	}

    /// <summary>
    ///  This method calulates the acutal player position and makes the camera follow it
    /// </summary>
    public void FollowPlayer()
    {
        // Make the player coordinates the target coordinates for the new camera position
        float targetX = player.transform.position.x;

        float targetY = player.transform.position.y;

        // If the player has moved beyond the x margin 
        if (CheckXMargin())
        {
            /*
             *  The targetX coordinate should be a calculated point between camera and player position
             *  To avoid camera jumps, the xSmooth affects this
             */
            targetX = Mathf.Lerp(this.transform.position.x, player.transform.position.x, xSmooth * Time.deltaTime);
        }

        if (CheckYMargin())
        {
            /*
             *  The targetY coordinate should be a calculated point between camera and player position
             *  To avoid camera jumps, the ySmooth affects this
             */
            targetX = Mathf.Lerp(this.transform.position.y, player.transform.position.y, ySmooth * Time.deltaTime);
        }


        /*
         *  The target cooridnates shouldn't be larger than the maximum or smaller than the minimum
         *  By using Mathf, this will be the case
         *  If the value is > max, then it should be the max
         *  If the value is < min, then it should be the min
         *  If the value is inbetween, the value will be returned
         */
        targetX = Mathf.Clamp(targetX, minX, maxX);
        targetY = Mathf.Clamp(targetY, minY, maxY);

        // Set the new camera position to the calculated target , keep the z-axis value
        this.transform.position = new Vector3(targetX, targetY, this.transform.position.z);    
    }

    /// <summary>
    ///  This method checks, if the distance between the camera and the player 
    ///  along the x axis is greater then the x margin
    /// </summary>
    /// <returns>If the distance is greater than x margin, return true</returns>
    private bool CheckXMargin()
    {
        // Calculate the distance between camera and player on x-axis and compare it with x margin
        return Mathf.Abs(transform.position.x - player.transform.position.x) > xMargin;
    }

    /// <summary>
    ///  This method checks, if the distance between the camera and the player 
    ///  along the y axis is greater then the y margin
    /// </summary>
    /// <returns>If the distance is greater than y margin, return true</returns>
    private bool CheckYMargin()
    {
        // Calculate the distance between camera and player on y axis and compare it with y margin
        return Mathf.Abs(transform.position.y - player.transform.position.y) > yMargin;
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
