using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Player_Position : MonoBehaviour {

    private GameObject m_player;

    public Vector3 m_StartPosition;


	// Use this for initialization
	void Start ()
    {
        m_player = gameObject;

        if (!CheckIfPlayerShouldMove())
        {
            FreezePlayer();
        }
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
        List<int> loadedScences = new List<int>();

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            loadedScences.Add(scene.buildIndex);
        }

        foreach(int scene in loadedScences)
        {
            if(scene >= 2)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// This method freezes the players position
    /// </summary>
    public void FreezePlayer()
    {
        m_player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        m_player.GetComponent<SpriteRenderer>().enabled = false;
    }

    /// <summary>
    /// This method let the player move again
    /// </summary>
    public void UnfreezePlayer()
    {
        m_player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        m_player.GetComponent<SpriteRenderer>().enabled = true;
    }
}
