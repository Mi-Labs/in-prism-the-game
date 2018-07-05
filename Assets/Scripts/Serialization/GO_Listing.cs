using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GO_Listing {

    private List<GameObject> m_GOList = new List<GameObject>();

    public void SaveLevelStat()
    {
        if(m_GOList.Count == 0)
        {
            GameObject levelgen = GameObject.FindGameObjectWithTag("LevelGenerator");

            Transform[] levelElements = levelgen.GetComponentsInChildren<Transform>();

            foreach (Transform t in levelElements)
            {
                m_GOList.Add(t.gameObject);
            }
        }
        else
        {
            m_GOList.Clear();
        }

    }

    public void PrintGOList()
    {
        int i = 1;
        foreach(GameObject go in m_GOList)
        {
            Debug.Log(i+": " + go.name);
            i++;
        }
        Debug.Log(m_GOList.Count);
    }
    
    public List<GameObject> GetGOLevelList()
    {
        if(m_GOList.Count == 0)
        {
            SaveLevelStat();
        }
        return m_GOList;
    }
}
