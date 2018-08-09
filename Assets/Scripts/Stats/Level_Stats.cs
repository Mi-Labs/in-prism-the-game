using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds the statistics for every level
/// </summary>
public class Level_Stats : MonoBehaviour {
    
    // Holds the status of the level complition
    [SerializeField]
    private bool m_IsComplete;

    // Holds time that has passed since the scene has started
    [SerializeField]
    private float m_Leveltime;

    //Holds the amount of saved spheres
    [SerializeField]
    private int m_Savedspheres;

    [SerializeField]
    private int m_NumberOfDeaths;

    [SerializeField]
    private int m_ActualSceneNumber;

    
	// Use this for initialization
	void Start ()
    {        
        m_ActualSceneNumber = gameObject.scene.buildIndex;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //updates the leveltime
        if (!m_IsComplete)
        {
            m_Leveltime = Time.timeSinceLevelLoad;
        }
           
	}

   public float GetLevelTime()
    {
        return m_Leveltime;
    }
    
    public int GetNumberOfDeaths()
    {
        return m_NumberOfDeaths;
    }
    
    public void AddDeath()
    {
        m_NumberOfDeaths++;
        GlobalStatistics.IncreaseNumberOfDeath(1);
        Debug.Log(GlobalStatistics.m_numberOfDeath);
    }


    public int GetNumberOfSavedSpheres()
    {
        return m_Savedspheres;
    }

    public void AddSavedSphere()
    {
        m_Savedspheres++;
    }

    public int GetLevelNumber()
    {
        return m_ActualSceneNumber;
    }
}
