using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowMoveTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(Camera.main.gameObject);
        Camera.main.gameObject.GetComponent<CameraFlow>().enabled=true; //aktivates the smooth camera follow
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
