﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LevelSave {

    /* Fields */

    public List<Vector2Ser> m_colorChangedObjectPosition = new List<Vector2Ser> ();

    public int m_levelnumber = GameObject.FindGameObjectWithTag("LevelGenerator").scene.buildIndex;


    /* Methods */

    /// <summary>
    /// Add a position of an colorchanged object to the list
    /// </summary>
    /// <param name="_position">Position of the object, that should be listed</param>
    public void AddColorChange(Vector2 _position)
	{
        if(!CheckIfSaved(_position))
        {
            m_colorChangedObjectPosition.Add(new Vector2Ser(_position));
        }
		else
        {
            Debug.Log("Object already in list");
        }
	}


	public void FillColorList()
	{
        
        GameObject levelgen = GameObject.FindGameObjectWithTag("LevelGenerator");
        ChangedValues[] changedValues = levelgen.GetComponentsInChildren<ChangedValues>();
        foreach (ChangedValues cv in changedValues)
            {
                if (cv.m_IsChanged)
                {
                    AddColorChange(cv.m_GOPosition);
                    // Debug.Log(cv.m_GOPosition);
                }
            }
        Debug.Log("All changed objects are listed");
	}

    private bool CheckIfSaved(Vector2 _position)
    {
        foreach (Vector2Ser pos in m_colorChangedObjectPosition)
        {
            if (pos.GetVector2().Equals(_position))
            {
                return true;
            }
        }
        return false;
    }
}
