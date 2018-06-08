using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerToPosition : MonoBehaviour {

    private GameObject m_player;

	// Use this for initialization
	void Start ()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");

        if(m_player == null)
        {
            Debug.LogError("Player not found");
        }

        Player_Position positionScript = m_player.GetComponent<Player_Position>();
        
        if(positionScript != null )
        {
            positionScript.SetPosition(this.transform.position);
        }
        else
        {
            Debug.Log("Player_Position script was not found");
        }
            
	}
	
}
