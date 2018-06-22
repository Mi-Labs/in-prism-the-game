using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class Player_Position : MonoBehaviour {

    private GameObject m_player;

    public Vector3 m_StartPosition;

    private static Manager m_SceneManager;

	// Use this for initialization
	void Start ()
    {
        m_player = gameObject;
        m_SceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Manager>();
	}
    
    private void Update()
    {   
        // Safety check <- If Player is out of Bounds
        if(m_player.transform.position.y < -100)
        {
            // Debug.LogError("Player out of bounds");
            SetPlayerToStartPosition();
        }
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


    /// <summary>
    /// This method freezes the players position
    /// </summary>
    public void FreezePlayer()
    {
        m_player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }


    /// <summary>
    /// This method sets the start position for the player
    /// </summary>
    /// <param name="_position">Start position</param>
    public void SetStartPosition(Vector3 _position)
    {
        m_StartPosition = _position;
    }


    /// <summary>
    /// This method sets the player to the start position
    /// </summary>
    public void SetPlayerToStartPosition()
    {
        // Set player to the assigned start position
        m_player.transform.position = m_StartPosition;

        // Set the players velocity to zero
        m_player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Checks if the player should move
        if(!CheckIfPlayerShouldMove())
        {
            FreezePlayer();
        }
        else
        {
            UnfreezePlayer();
        }
    }


    /// <summary>
    ///  This method checks if the player should move
    /// </summary>
    /// <returns></returns>
    private bool CheckIfPlayerShouldMove()
    {
        int scenenumber = (int)m_SceneManager.GetCurrentScene();

        if(scenenumber > 2 && scenenumber <= (int)Manager.EScene.NumberOfScenes)
        {
            return true;
        }
        return false;
    }


    /// <summary>
    /// This method let the player move again
    /// </summary>
    public void UnfreezePlayer()
    {
        m_player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
