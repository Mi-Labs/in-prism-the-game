using UnityEngine;

public class SetPlayerToPosition : MonoBehaviour {

    private GameObject m_player;

	// Use this for initialization
	void Start ()
    {
        // Search for player GO
        m_player = GameObject.FindGameObjectWithTag("Player");

        // If player is not found...
        if(m_player == null)
        {
            Debug.LogError("Player not found");
        }

        // Search for the player position script
        Player_Position positionScript = m_player.GetComponent<Player_Position>();
        
        // If the script is found...
        if(positionScript != null )
        {
            positionScript.SetStartPosition(this.transform.position);
            positionScript.SetPlayerToStartPosition();
        }
        else
        {
            Debug.Log("Player_Position script was not found");
        }        
	}
}
