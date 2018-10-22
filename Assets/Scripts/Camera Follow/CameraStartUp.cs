using UnityEngine;

/// <summary>
///  This script adds the follow script to the main camera and destroys itself
///  afterwards
/// </summary>
public class CameraStartUp : MonoBehaviour {


    /* Fields */

    private static CameraFollow m_FollowScript = null;


    /* Methods */

    void Start ()
    {
        // Try to get the camera follow script
        m_FollowScript = Camera.main.GetComponent<CameraFollow>();

        // If no camera follow script is found -> add it to the main camera
        if(m_FollowScript == null)
        {
            m_FollowScript = Camera.main.gameObject.AddComponent<CameraFollow>();
            m_FollowScript.InsertLevelGen(gameObject);
        }

        // Destroy this script
        Destroy(this);
	}
}
