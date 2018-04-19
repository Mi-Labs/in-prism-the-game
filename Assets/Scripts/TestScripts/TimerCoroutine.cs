using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerCoroutine : MonoBehaviour {

    private int waittime;
    

	// Use this for initialization
	void Start () {}

    private void OnEnable()
    {
     //   EventManager.StartListening("StartCountdown_Boost_A", StartCountdown();
    }

    private void OnDisable()
    {
    //    EventManager.StopListening("StartCountdown_Boost_A", StartCountdown);
    }

    void StartCountdown(int waittime)
    {
        StartCoroutine(Countdown(waittime));
    }

    // Update is called once per frame
    void Update () {
		
	}

    private IEnumerator Countdown(int waitTime)
    {      
        yield return new WaitForSecondsRealtime(waitTime);
        EventManager.TriggerEvent("Timer_Is_Ready");
    }

}
