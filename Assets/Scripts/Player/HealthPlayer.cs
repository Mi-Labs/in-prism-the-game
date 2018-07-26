using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagement;

public class HealthPlayer : MonoBehaviour {

    /* Fields */

    // Holds the current amount of lifepoints
    private int lifepoints;

    // maximal health points of the player
    private const int maxlifepoints = 100;

    // Holds the status of invulnerability
    private bool isInvulnerable;

    private ChangeLifeFilling m_FillingScript;

    // private World_Stats stats;

    private SceneManagerPlayScene m_ManagerPlay;


    /* Methods */

	// Use this for initialization
	void Start ()
    {
        // On Start the lifepoints should be at maximum
        lifepoints = maxlifepoints;

        // Set isInvulnerable to false -> only true when powerup is active
        isInvulnerable = false;

        m_FillingScript = gameObject.GetComponentInChildren<ChangeLifeFilling>();
	}

    /// <summary>
    /// This method decreases the life point with the given parameter
    /// </summary>
    /// <param name="damage">The amount of lifepoints, that should be decreased</param>
    public void DecreaseLife(int _damage)
    {
        // Debug.Log("Method DecreaseLife was called with "+ _damage +" Damage!");

        if(!isInvulnerable)
        {
            // Check if with the new life point value is greater than zero
            if(lifepoints - _damage < 0)
            {
                lifepoints = 0;
            }
            else
            {
                // Calculate the lifepoints, that are left after the decrease
                lifepoints = lifepoints - _damage;
            }

            // Change the text on the life bar
            ChangeLifeBar(lifepoints);

            // If the lifepoints are below or zero, reset this scene
            if (lifepoints <= 0) //Be Aware of a possible Bug
            {
                // Reset the life points to maximum after reset
                ResetLifePoints();

                // Resets the Level
                ResetLevel();
            }
        }   
    }

    /// <summary>
    /// This method increases the lifepoints of the player with the given parameter
    /// </summary>
    /// <param name="_life">The amount of lifepoints, that should be added</param>
    public void IncreaseLife(int _life)
    {
        //If the lifepoints + the parameter are more ore equal of the maximal life point time -> set lifepoints to maximum
        if(lifepoints + _life >= maxlifepoints)
        {
            // Set lifepoints to maximum
            lifepoints = maxlifepoints;
        }
        else
        {
            // Add the parameter value to the lifepoints
            lifepoints =+ _life;
        }
        // Change displayed lifepoints
        ChangeLifeBar(lifepoints);
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
    /// This method changes the Value of the life bar
    /// </summary>
    private void ChangeLifeBar(int _lifepoints)
    {
        m_FillingScript.SetNewLifePoint(_lifepoints);
    }

    /// <summary>
    /// This method toggles the status of Invulnerability
    /// </summary>
    public void ToogleIsInvulnerable(bool status)
    {
        isInvulnerable = (status) ? true : false;        
    }


    /// <summary>
    /// This method resets the lifepoints to the maximum / startvalue;
    /// </summary>
    private void ResetLifePoints()
    {
        IncreaseLife(maxlifepoints);
    }


    /// <summary>
    /// This method resets the level
    /// </summary>
    private void ResetLevel()
    {
        GameObject sceneController = GameObject.FindGameObjectWithTag("GameController");

        // Find Scene Controller
        m_ManagerPlay = sceneController.GetComponent<SceneManagerPlayScene>();

        // Add death to statistic
        sceneController.GetComponent<Level_Stats>().AddDeath();

        // Reset Scene
        m_ManagerPlay.ResetScene();

        // Sets player to start position
        gameObject.GetComponent<Player_Position>().SetPlayerToStartPosition();
    }  
}
