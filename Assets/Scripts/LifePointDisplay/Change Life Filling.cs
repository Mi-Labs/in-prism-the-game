using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLifeFilling : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.rotation = Quaternion.Inverse(gameObject.transform.parent.rotation);
	}
}
