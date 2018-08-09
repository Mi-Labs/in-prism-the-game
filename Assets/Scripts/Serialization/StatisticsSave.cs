using UnityEngine;

[System.Serializable]
public class StatisticsSave
{
    /* Fields */

    public GlobalStatistics m_Save;


    /* Constructor */

    /// <summary>
    /// Constructor for StatisticsSave
    /// </summary>
    /// <param name="_savedData">The data, that should be saved</param>
    public StatisticsSave(GlobalStatistics _savedData)
    {
        // If the given data is valid ...
        if(_savedData != null)
        {
            m_Save = _savedData;
        }
        else
        {
            Debug.LogError("Invalid save data");
        }
    }


    /* Methods */

    /// <summary>
    /// This method returns the saved data
    /// </summary>
    /// <returns>Returns the saved statistic data</returns>
    public GlobalStatistics GetSaveData()
    {
        return m_Save;
    }
}
