using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayer : MonoBehaviour {

    public GameObject player;
    

	// Use this for initialization
	void Start ()
    {
        Instantiate(player, this.transform.position, Quaternion.identity, this.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
