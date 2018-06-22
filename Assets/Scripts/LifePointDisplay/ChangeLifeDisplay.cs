using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLifeDisplay : MonoBehaviour {

    private Text m_LifeDisplay;

	// Use this for initialization
	void Start ()
    {
        m_LifeDisplay = gameObject.GetComponent<Text>();
	}
	
	public System.String GetActualContent()
    {
        return m_LifeDisplay.text;
    }

    public void SetActualContent(System.String _newContent)
    {
        m_LifeDisplay.text = _newContent;
    }

}
