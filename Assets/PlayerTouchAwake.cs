using UnityEngine;

public class PlayerTouchAwake : MonoBehaviour {


    // Field to control if the player should be touchable
    public bool m_ActivatePlayer;

	// Use this for initialization
	void Start ()
    {
		if(m_ActivatePlayer == true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Control>().m_PlayerIsSelectable = true;
        }
	}
	

}
