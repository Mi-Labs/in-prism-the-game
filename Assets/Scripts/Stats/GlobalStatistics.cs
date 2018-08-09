using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalStatistics {

    public static int m_numberOfDeath;
    public static float m_playTime;
    public static int m_playedLevel;
    public static int saved_orbits;  
    
    public static void IncreaseNumberOfDeath(int _change)
    {
        if(_change > 0)
        {
            Debug.Log("GS Death increased by" + _change);
            m_numberOfDeath += _change; 
        }
    }

    public static void UpdatePlayTime(int _newValue)
    {
        m_playedLevel = _newValue;
    }

    public static int GetNumberOfDeath()
    {
        return m_numberOfDeath;
    }

    public override string ToString()
    {
        return m_numberOfDeath + "$" + m_playTime + "$" + m_playedLevel + "$" + saved_orbits + "$";
    }

}
