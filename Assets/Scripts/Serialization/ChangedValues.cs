using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChangedValues : MonoBehaviour {
    
    public bool m_IsChanged;

    public bool m_IsColorful;

    public int m_CageStatus;

    public Vector2 m_GOPosition;

	// Use this for initialization
	void Start ()
    {
        m_IsChanged = false;
        m_CageStatus = 3;
        m_IsColorful = false;
        m_GOPosition = (Vector2)gameObject.transform.position;
	}
	
    public void ColorChanged(bool _status)
    {
        m_IsColorful = _status ? true : false;
        if(m_IsColorful)
        {
            if(!m_IsChanged)
            {
                IsChanged(true);
            }
        }
    }

    public void CageStageChanged(int _newState)
    {
        m_CageStatus = _newState;
        if(m_CageStatus != 3)
        {
            if(!m_IsChanged)
            {
                IsChanged(true);
            }
        }
    }
    
    private void IsChanged (bool _status)
    {
        m_IsChanged = _status ? true : false;
    }
}
