using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Position : MonoBehaviour {

    private GameObject m_player;

	// Use this for initialization
	void Start ()
    {
        m_player = gameObject;	
	}
	
    /// <summary>
    /// This method sets the player to a specific position
    /// </summary>
    /// <param name="_position">The new position of the player</param>
    public void SetPosition (Vector3 _position)
    {
        m_player.transform.position = _position;
    }


    /// <summary>
    /// This method returns the actual position of the player
    /// </summary>
    /// <returns></returns>
    public Vector3 GetPosition()
    {
        return m_player.transform.position;
    }
}
