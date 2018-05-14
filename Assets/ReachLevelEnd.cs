using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachLevelEnd : MonoBehaviour {
    public GameObject pictureText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("LädText");
        Instantiate(pictureText, this.transform.position, Quaternion.identity, transform);
    }
}
