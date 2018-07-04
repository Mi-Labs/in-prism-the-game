using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script by https://www.youtube.com/watch?v=QkisHNmcK7Y

public class ParallaxScrolling : MonoBehaviour {

    /* Fields */

    // Holds the horizontal size of the background
    public float m_backgroundSize;

    // Holds the movement speed for the parallax effect
    public float m_ParallaxSpeed;

    // Holds the status of scrolling and the parallax effect
    public bool m_IsScrolling;
    public bool m_ParallaxEnabled;

    // Holds the start transform of the main camera
    private Transform m_CameraTransform;

    //Holds all transforms of the children of this GO
    private Transform[] m_Layers;

    // Holds the viewZone (what the player is seeing)
    private float m_ViewZone;

    // Holds the actual seen position for the layer
    private int m_LeftIndex;
    private int m_RightIndex;

    // Holds the last x postion of the main camera
    private float m_LastCameraX;


    /* Methods */

    void Start ()
    {
        // Get the actual camera transform
        m_CameraTransform = Camera.main.transform;

        // Initalize various fields
        m_LastCameraX = m_CameraTransform.position.x;
        m_LeftIndex = 0;
        m_RightIndex = m_Layers.Length - 1;
        m_ViewZone = 10.0f;

        // Create an array with all children of this GO
        m_Layers = new Transform[transform.childCount];
        for (int i = 0;i < transform.childCount;i++)
        {
            m_Layers[i] = transform.GetChild(i);
        }     
	}

    private void Update()
    {
        // If the parallax effect should be applied ...
        if(m_ParallaxEnabled)
        {
            float deltaX = m_CameraTransform.position.x - m_LastCameraX;

            transform.position += Vector3.right * (deltaX * m_ParallaxSpeed);
        }

        // Update lastCameraX
        m_LastCameraX = m_CameraTransform.position.x;

        // If the scrolling effect should be applied ...
        if(m_IsScrolling)
        {
            if (m_CameraTransform.position.x < (m_Layers[m_LeftIndex].transform.position.x + m_ViewZone))
            {
                ScrollLeft();
            }
            if (m_CameraTransform.position.x > (m_Layers[m_RightIndex].transform.position.x - m_ViewZone))
            {
                ScrollRight();
            }
        }
    }

    private void ScrollLeft()
    {
        m_Layers[m_RightIndex].position = Vector3.right * (m_Layers[m_LeftIndex].position.x - m_backgroundSize);
        m_LeftIndex = m_RightIndex;
        m_RightIndex--;
        // If right index is on the left end -> set it to the right end
        if(m_RightIndex < 0)
        {
            m_RightIndex = m_Layers.Length - 1;
        }
    }

    private void ScrollRight()
    {       
        m_Layers[m_LeftIndex].position = Vector3.right * (m_Layers[m_RightIndex].position.x + m_backgroundSize);
        m_RightIndex = m_LeftIndex;
        m_LeftIndex++;
        // If left index ist on the right end -> set it to start position
        if (m_LeftIndex  == m_Layers.Length)
        {
            m_LeftIndex = 0;
        }
    }
}
