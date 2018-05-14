using System;
using UnityEngine;


    public class CameraFlow : MonoBehaviour
    {
        public float xMargin = 1f; // Distance in the x axis the player can move before the camera follows.
        public float yMargin = 1f; // Distance in the y axis the player can move before the camera follows.
        public float xSmooth = 8f; // How smoothly the camera catches up with it's target movement in the x axis.
        public float ySmooth = 8f; // How smoothly the camera catches up with it's target movement in the y axis.
                                   // The maximum x and y coordinates the camera can have.
    public GameObject levelGen;
    public float maxX = 50;  // The maximum x and y coordinates the camera can have.
    public float maxY = 50;
    public float minX = 0.1f; // The minimum x and y coordinates the camera can have.
    public float minY = 0.1f;
    public Vector2 offset;
        private Transform m_Player; // Reference to the player's transform.


        void Start()
        {
            // Setting up the reference.
            m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        // Debug.Log("Player_transform was found");
        // Save camera z position
        levelGen = GameObject.Find("LevelGenerator");
        float cameraZ = transform.position.z;

        // Save the position of the player (only x and y)
        //Debug.Log(m_Player.position);
        Vector2 positionPlayer = (Vector2)m_Player.position;
        

        // Calculate the new CameraPosition (x and y of the player)
        Vector3 newCameraPosition = positionPlayer;

        // Replace the z-position of the new CameraPosition with the saved camera z-positon
        newCameraPosition.z = cameraZ;

        // Set the calculated camera position to the position of this gameObject
        this.transform.position = newCameraPosition;

        // Calculate offset => Position camera - Position player
        //offset = transform.position - m_Player.transform.position;
        maxX = levelGen.GetComponent<Level_Generator>().levelmap.width-(levelGen.GetComponent<Level_Generator>().levelmap.width/10);
        maxY = levelGen.GetComponent<Level_Generator>().levelmap.height;
    }


        private bool CheckXMargin()
        {
            // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
            return Mathf.Abs(transform.position.x - m_Player.position.x) > xMargin;
        }


        private bool CheckYMargin()
        {
            // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
            return Mathf.Abs(transform.position.y - m_Player.position.y) > yMargin;
        }


        private void Update()
        {
            TrackPlayer();
        }


        private void TrackPlayer()
        {
            // By default the target x and y coordinates of the camera are it's current x and y coordinates.
            float targetX = m_Player.position.x;
            float targetY = m_Player.position.y;
        //Debug.Log(m_Player.position.x);
          //  Debug.Log(m_Player.position.y);
        
            // If the player has moved beyond the x margin...
            if (CheckXMargin())
            {
                // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
                targetX = Mathf.Lerp(transform.position.x, m_Player.position.x, xSmooth*Time.deltaTime);
            }

            // If the player has moved beyond the y margin...
            if (CheckYMargin())
            {
                // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
                targetY = Mathf.Lerp(transform.position.y, m_Player.position.y, ySmooth*Time.deltaTime);
            }
            
            // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
            targetX = Mathf.Clamp(targetX, minX, maxX);
            
            targetY = Mathf.Clamp(targetY, minY, maxY);
            
            // Set the camera's position to the target position with the same z component.
            this.transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }