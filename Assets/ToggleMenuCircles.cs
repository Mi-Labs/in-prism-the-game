using UnityEngine;

public class ToggleMenuCircles : MonoBehaviour {

    public GameObject m_MainCircle;

    public GameObject m_Controls;

    public GameObject m_Sounds;

    public GameObject m_Voice;

    public void  GoBackToMainCircle()
    {
        if(m_Controls.activeSelf)
        {
            m_MainCircle.SetActive(true);
            m_Controls.SetActive(false);
        }
        else if(m_Sounds.activeSelf)
        {
            m_MainCircle.SetActive(true);
            m_Sounds.SetActive(false);
        }
        else if(m_Voice.activeSelf)
        {
            m_MainCircle.SetActive(true);
            m_Voice.SetActive(false);
        }
    }

    public void GoToControls()
    {
        m_MainCircle.SetActive(false);
        m_Controls.SetActive(true);
    }

    public void GoToVoice()
    {
        m_MainCircle.SetActive(false);
        m_Voice.SetActive(true);
    }

    public void GoToSounds()
    {
        m_MainCircle.SetActive(false);
        m_Sounds.SetActive(true);
    }

}
