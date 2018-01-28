using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Stats : MonoBehaviour {
    
    // Holds the status of the level complition
    [SerializeField]
    private bool is_complete;

    // Holds time that has passed since the scene has started
    [SerializeField]
    private float leveltime;

    //Holds the amount of saved spheres
    [SerializeField]
    private int savedspheres;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //updates the leveltime
        leveltime = Time.timeSinceLevelLoad;	
	}
}
