using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GO_Listing {

    public List<GameObject> m_GOList = new List<GameObject>();

    public int m_levelnumber;

    public void SaveLevelStat()
    {
        if(m_GOList.Count == 0)
        {
            GameObject levelgen = GameObject.FindGameObjectWithTag("LevelGenerator");

            ChangedValues[] levelElements = levelgen.GetComponentsInChildren<ChangedValues>();

            foreach (ChangedValues change in levelElements)
            {
                if(change.m_IsChanged)
                {
                    m_GOList.Add(change.gameObject);
                }
            }

            m_levelnumber = levelgen.scene.buildIndex;
        }
        else
        {
            m_GOList.Clear();
            SaveLevelStat();
        }

    }

    /// <summary>
    /// This method prints out all elements in the List
    /// </summary>
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
    
    public GO_Listing GetGOLevelList()
    {
        if (m_GOList.Count == 0)
        {
            SaveLevelStat();
        }
        return this;
    }
}
