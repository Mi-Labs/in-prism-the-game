using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyForPlayer : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = this.gameObject;	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FixedJoint fixedJoint = player.AddComponent<FixedJoint>();
        fixedJoint.anchor = collision.gameObject.transform.position;
        fixedJoint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
    }

}
