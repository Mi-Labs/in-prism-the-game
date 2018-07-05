using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldLevelGO : MonoBehaviour {

    public List<List<GameObject>> m_levelList; 

    public bool m_IsSaving;

    private void Awake()
    {
        m_IsSaving = false;
        m_levelList = new List<List<GameObject>>();
    }

    public void AddLevelStat()
    {
        GO_Listing levelstatus = new GO_Listing();
        m_levelList.Add(levelstatus.GetGOLevelList());
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
