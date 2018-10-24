using UnityEngine;

public class PlayerTouchAwake : MonoBehaviour {

    /* Fields */

    // Field to control if the player should be touchable
    public bool m_ActivatePlayer;

    /* Methods */

	// Use this for initialization
	void Start ()
    {
        // If th Player is touchable
		if(m_ActivatePlayer == true)
        {
            // Activate the menu option for the player
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Control>().m_PlayerIsSelectable = true;
        }
	}
}
