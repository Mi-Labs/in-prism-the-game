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
	
	//// Update is called once per frame
	//void Update ()
    //   {
    //       //updates the leveltime
    //       if (!m_IsComplete)
    //       {
    //           m_Leveltime = Time.timeSinceLevelLoad;
    //       }     
	//   }

    /// <summary>
    ///  This method returns the leveltime
    /// </summary>
    /// <returns>The time that has passed since the level </returns>
   public float GetLevelTime()
    {
        return Time.timeSinceLevelLoad;
    }
    

    /// <summary>
    /// This method returns the numbers of deaths in this level
    /// </summary>
    /// <returns></returns>
    public int GetNumberOfDeaths()
    {
        return m_NumberOfDeaths;
    }
    

    /// <summary>
    /// This method adds an death to the static (level & global)
    /// </summary>
    public void AddDeath()
    {
        m_NumberOfDeaths++;
        GlobalStatistics.Instance.IncreaseNumberOfDeath(1);
            }


    /// <summary>
    /// This method returns the number of saved spheres
    /// </summary>
    /// <returns>The number of saved spheres</returns>
    public int GetNumberOfSavedSpheres()
    {
        return m_Savedspheres;
    }


    /// <summary>
    /// This method add a saved sphere to the statistic 
    /// </summary>
    public void AddSavedSphere()
    {
        m_Savedspheres++;
    }

    /// <summary>
    /// This method gets the actual levelnumber
    /// </summary>
    /// <returns>The buildnummer of the current level</returns>
    public int GetLevelNumber()
    {
        return m_ActualSceneNumber;
    }
}
