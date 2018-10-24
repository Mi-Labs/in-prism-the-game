using UnityEngine;

[System.Serializable]
public class GlobalStatistics {

    public static GlobalStatistics instance = null;

    [SerializeField]
    private int m_numberOfDeath;
    [SerializeField]
    private float m_playTime;
    public int m_playedLevel;
    public int m_saved_orbits;

    public bool m_Deleted;

    public static GlobalStatistics Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GlobalStatistics();
            }
            return instance;
        }
    }

    public void IncreaseNumberOfDeath(int _change)
    {
        if(_change > 0)
        {
            m_numberOfDeath += _change; 
        }
    }

    public void UpdatePlayTime(float _newValue)
    {
        if(m_playTime == 0.0f)
        {
            m_playTime = _newValue;
        }
        else
        {
            m_playTime += _newValue;
        }   
    }

    public int GetNumberOfDeath()
    {
        return m_numberOfDeath;
    }

    public void SetNumberOfDeath(int _number)
    {
        m_numberOfDeath = _number;
    }

    public float GetPlayTime()
    {
        return m_playTime;
    }
    /// <summary>
    /// This method sets the playtime
    /// </summary>
    /// <param name="_time"></param>
    public void SetPlayTime(float _time)
    {
        m_playTime = _time;
    }

    /// <summary>
    /// This method set the statistics for destruction
    /// </summary>
    public void ToogleDestruction(bool _status)
    {
        if(!m_Deleted)
        {
            m_Deleted = true;
        }
        else
        {
            m_Deleted = false;
        }
    }
}
