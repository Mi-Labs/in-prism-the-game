using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour {


    /* Variables */

    // Holds the current amount of lifepoints
    private int lifepoints;

    // maximal healthpoints of the player
    private const int maxlifepoints = 100;

    // Holds the status of invulnerability
    private bool isInvulnerable;



    /* Methods */

	// Use this for initialization
	void Start ()
    {
        // On Start the lifepoints should be at maximum
        lifepoints = maxlifepoints;

        // Set isInvulnerable to false -> only true when powerup is active
        isInvulnerable = false;
	}

    /// <summary>
    /// This method decreases the lifepoint with the given parameter
    /// </summary>
    /// <param name="damage">The amount of lifepoints, that should be decreased</param>
    public void DecreaseLife(int damage)
    {
        if(!isInvulnerable)
        {
            //Debug.Log("Damage " + damage);

            // Calculate the lifepoints, that are left after the decrease
            lifepoints = lifepoints - damage;

            //Debug.Log("LifeP" + lifepoints);

            // Change the text on the lifebar
            ChangeLifeBar();

            // If the lifepoints are below zero, reset this scene
            if (lifepoints <= 0)
            {
                // Get the buildindex of the active scence
                int activescene = SceneManager.GetActiveScene().buildIndex;

                // Reload the scence
                SceneManager.LoadScene(activescene);
            }
        }   
    }

    /// <summary>
    /// This method increases the lifepoints of the player with the given parameter
    /// </summary>
    /// <param name="life">The amount of lifepoints, that should be added</param>
    public void IncreaseLife(int life)
    {
        //If the lifepoints + the parameter are more ore equal of the maximal lifepoint time -> set lifepoints to maximum
        if(lifepoints + life >= maxlifepoints)
        {
            // Set lifepoints to maximum
            lifepoints = maxlifepoints;
        }
        else
        {
            // Add the parameter value to the lifepoints
            lifepoints =+ life;
        }
    }

    /// <summary>
    /// This method gives the current lifepoints
    /// </summary>
    /// <returns>Returns the current lifepoints</returns>
    public int GetLifePoints()
    {
        return lifepoints;
    }

    /// <summary>
    /// This method gives the maximal lifepoints
    /// </summary>
    /// <returns>Returns the maximal lifepoints</returns>
    public int GetMaxLifePoints()
    {
        return maxlifepoints;
    }

    /// <summary>
    /// This method changes the Value of the lifebar
    /// </summary>
    private void ChangeLifeBar()
    {
        // Get the ReadPlayerTime script and change the value of the lifebar to the actual value
        this.GetComponent<ReadPlayerTime>().ChangeTextValue();
    }

    /// <summary>
    /// This method toggles the status of Invulnerability
    /// </summary>
    public void ToogleIsInvulnerable(bool status)
    {
        // If the powerUp Invulnerability is active
        if(status == true)
        {
            isInvulnerable = true;
        }
        else
        {
            isInvulnerable = false;
        }
    }
}
