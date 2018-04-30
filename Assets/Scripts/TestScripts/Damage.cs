using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public int objectdamage; 

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collison Found");
        GameObject hit = collision.gameObject;
        if(hit.tag == "Player")
        {
            Debug.Log("Player hit me");
            int maxlife = hit.GetComponent<HealthPlayer>().GetMaxLifePoints();
            Debug.Log(objectdamage + "ObjDmg");
            Debug.Log(maxlife + "maxlife");
            float damage = ((float)objectdamage / (float)maxlife)*100.0f;

            Debug.Log(damage);
            int outdamage = Mathf.RoundToInt(damage);
            
            hit.GetComponent<HealthPlayer>().DecreaseLife(outdamage);
            Debug.Log("Decrease with outdamage: " + outdamage);
            //Visueller Warnung - TD
        }
    }
}
