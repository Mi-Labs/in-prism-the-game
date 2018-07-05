using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldLevelGO : MonoBehaviour {

    public List<GO_Listing> m_levelList; 

    public bool m_IsSaving;

    private void Awake()
    {
        m_IsSaving = false;
        m_levelList = new List<GO_Listing>();
    }

    public void AddLevelStat()
    {
        GO_Listing actual_Level = new GO_Listing();
        m_levelList.Add(actual_Level.GetGOLevelList());
    }

    private void Update()
    {
        if(m_IsSaving)
        {
            AddLevelStat();
            m_IsSaving = false;
        }
    }


}
