using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleTextPanel : MonoBehaviour {

    public GameObject m_TextPanel;

	
	public void TooglePanel()
    {
        if(m_TextPanel.activeSelf)
        {
            m_TextPanel.SetActive(false);
        }
        else
        {
            m_TextPanel.SetActive(false);
        }
    }

    public void SetPanel(bool _status)
    {
        m_TextPanel.SetActive(_status);
    }
}
