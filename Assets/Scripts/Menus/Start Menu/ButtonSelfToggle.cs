using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelfToggle : MonoBehaviour {

    public int m_OwnLevelNumber;

    private int m_HighestNumber;

	// Use this for initialization
	void Start ()
    {
        m_HighestNumber = GameObject.FindGameObjectWithTag("LevelSave").GetComponent<WorldObjectSave>().GetHighestLevelNumber();
        if (m_OwnLevelNumber < m_HighestNumber)
        {
            gameObject.SetActive(false);
        }
	}
	
}
