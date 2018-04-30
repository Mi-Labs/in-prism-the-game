using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadPlayerTime : MonoBehaviour {

    private int lifepoints;

    public Text lifetext;
    // Use this for initialization

	void Start ()
    {
        lifetext = GameObject.Find("LifePlayerText").GetComponent<Text>();
        
        //lifepoints = this.GetComponent<HealthPlayer>().GetMaxLifePoints();
        //Debug.Log(lifepoints);
        ChangeTextValue();
    }
	
	// Update is called once per frame
	void Update ()
    {
      
	}

    public void ChangeTextValue()
    {
        lifepoints = this.GetComponent<HealthPlayer>().GetLifePoints();
        lifetext.text = lifepoints.ToString();
    }
}
