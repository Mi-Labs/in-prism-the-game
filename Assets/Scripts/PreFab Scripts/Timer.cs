using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    // Holds actual time + time to wait
    private float endtime;

    // Holds the remaining time
    private float timeleft;

    // Holds the time to wait
    private int secondsToWait;

    //@Awake this method should not start -> only after calling SetTimer()
    private void Awake()
    {
       this.enabled = false;
    }

    // Use this for initialization
    void Start ()
    {
        // Check if data is correct ( No countdown from 0 or below)
        if (secondsToWait > 0)
        {
            // endtime = actual time + the time we will count down
            endtime = Time.time + secondsToWait;

            // @Start the left time should be our inital value
            timeleft = secondsToWait;
        }
        else
        {
            //If a inncorrect value is given to this script -> deacivation of the script
            Debug.LogError("Invalid Argument");

            this.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //In every frame is checked, if there is time left
	    if(timeleft> 0)
        {
            // new left time is endtime - actual systemtime
            timeleft = endtime - Time.time;

            // Debug.Log(timeleft);
        }
        else
        {
            //Send Message to parent GameObject
            transform.parent.gameObject.BroadcastMessage("TimeIsUp");

            // Debug.Log("TimeIsUp");

            //Destroy this Gameobject
            Destroy(this.gameObject);     
        }
	}

    /// <summary>
    /// This method starts the timer for a defined time
    /// </summary>
    /// <param name="seconds">The time, that the timer should run (in seconds)</param>
    public void StartTimer(int seconds)
    {
        //enable this script
        this.enabled = true;
        //set timerlength
        secondsToWait = seconds;
    }

    /// <summary>
    /// When Destroy() is called, do these actions
    /// </summary>
    public void OnDestroy()
    {
       // Debug.Log("Timer has been destroyed");
    }
}
