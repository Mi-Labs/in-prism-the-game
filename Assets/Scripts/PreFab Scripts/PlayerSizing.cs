using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizing : MonoBehaviour {

    [SerializeField]
    // private bool m_PlayerIsShrunken;

	// Use this for initialization
	void Start ()
    {
        // m_PlayerIsShrunken = false;	
	}
	

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if(_collision.collider.gameObject.tag == "Player")
        {
            GetComponent<Animator>().SetBool("PlayerHasArrived", true);
        }
    }
}
