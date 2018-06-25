using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script idea by https://www.youtube.com/watch?v=QkisHNmcK7Y

public class ParallaxScrolling : MonoBehaviour {

    public float m_backgroundSize;

    private Transform m_CameraTransform;
    private Transform[] m_Layers;

    private float m_ViewZone = 10.0f;

    private int m_LeftIndex;
    private int m_RightIndex;

	// Use this for initialization
	void Start ()
    {
        // Get the actual camera transform
        m_CameraTransform = Camera.main.transform;

        // Create an array with all children of this GO
        m_Layers = new Transform[transform.childCount];
        for (int i = 0;i < transform.childCount;i++)
        {
            m_Layers[i] = transform.GetChild(i);
        }

        m_LeftIndex = 0;
        m_RightIndex = m_Layers.Length - 1;
	}

    private void Update()
    {
        if(m_CameraTransform.position.x < (m_Layers[m_LeftIndex].transform.position.x + m_ViewZone))
        {
            ScrollLeft();
        }
        if (m_CameraTransform.position.x > (m_Layers[m_RightIndex].transform.position.x - m_ViewZone))
        {
            ScrollRight();
        }
    }

    private void ScrollLeft()
    {
        int lastRight = m_RightIndex;
        m_Layers[m_RightIndex].position = Vector3.right * (m_Layers[m_LeftIndex].position.x - m_backgroundSize);
        // 
        m_LeftIndex = m_RightIndex;
        m_RightIndex--;
        // If right index ist on the left end -> set it to the right end
        if(m_RightIndex < 0)
        {
            m_RightIndex = m_Layers.Length - 1;
        }
    }

    private void ScrollRight()
    {
        int lastLeft = m_LeftIndex;
        m_Layers[m_LeftIndex].position = Vector3.right * (m_Layers[m_RightIndex].position.x + m_backgroundSize);
        // 
        m_RightIndex = m_LeftIndex;
        m_LeftIndex++;
        // If right index ist on the left end -> set it to the right end
        if (m_LeftIndex  == m_Layers.Length)
        {
            m_LeftIndex = 0;
        }
    }
}
