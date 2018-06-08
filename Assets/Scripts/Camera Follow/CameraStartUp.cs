using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This script adds the follow script to the main camera and destroys itself
///  afterwards
/// </summary>
public class CameraStartUp : MonoBehaviour {

    private static CameraFollow m_FollowScript = null;

	// Use this for initialization
	void Start ()
    {
        m_FollowScript = Camera.main.GetComponent<CameraFollow>();

        if(m_FollowScript == null)
        {
            Camera.main.gameObject.AddComponent<CameraFollow>(); 
        }
        else
        {
            Debug.Log("Follow script was already there");
        }
        
        
        // Destroy this script
        Destroy(this);
	}
	
	
}
