using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This script adds the follow script to the main camera and destroys itself
///  afterwards
/// </summary>
public class CameraStartUp : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        // Add Script CameraFollow to main camera
        Camera.main.gameObject.AddComponent<CameraFollow>();
        // Destroy this script
        Destroy(this);
	}
	
	
}
