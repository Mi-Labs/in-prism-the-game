using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour {

    private int lifepoints;

    // maximal healthpoints of the player
    private const int maxlifepoints = 100;

	// Use this for initialization
	void Start ()
    {
        lifepoints = maxlifepoints;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DecreaseLife(int damage)
    {
        //if unvenerablity -> do nothing
        //else this
        Debug.Log("Damage " + damage);
        lifepoints = lifepoints - damage;
        Debug.Log("LifeP" + lifepoints);
        ChangeLifeBar();
        
       if(lifepoints <= 0)
       {
         int activescene = SceneManager.GetActiveScene().buildIndex;
          SceneManager.LoadScene(activescene);
       }
    }

    public void IncreaseLife(int life)
    {
        if(lifepoints + life >= maxlifepoints)
        {
            lifepoints = maxlifepoints;
        }
        else
        {
            lifepoints =+ life;
        }
    }

    public int GetLifePoints()
    {
        return lifepoints;
    }

    public int GetMaxLifePoints()
    {
        return maxlifepoints;
    }

    private void ChangeLifeBar()
    {
        this.GetComponent<ReadPlayerTime>().ChangeTextValue();
    }
}
