using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalStatistics {

    public int m_numberOfDeath;
    public float m_playTime;
    public int m_playedLevel;
    public int saved_orbits;  
    
    public void IncreaseNumberOfDeath(int _change)
    {
        if(_change > 0)
        {
            m_numberOfDeath += _change; 
        }
    }

    public void UpdatePlayTime(int _newValue)
    {
        m_playedLevel = _newValue;
    }

}
