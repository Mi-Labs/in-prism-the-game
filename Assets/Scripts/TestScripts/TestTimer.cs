using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  This class is only for Testing !!!
/// </summary>
public class TestTimer : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //Add a timer with 10 Seconds -> Waits 10 Seconds
        this.gameObject.AddComponent<Timer>().SetTimer(10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
