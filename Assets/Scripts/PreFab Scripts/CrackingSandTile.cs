using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackingSandTile : MonoBehaviour {

    public bool m_PlayerHasHit;

	// Use this for initialization
	void Start ()
    {
        m_PlayerHasHit = false;	
	}



    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if(_collision.gameObject.tag== "Player")
        {
            m_PlayerHasHit = true;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
