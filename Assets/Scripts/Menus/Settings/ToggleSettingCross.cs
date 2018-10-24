using UnityEngine;

public class ToggleSettingCross : MonoBehaviour {

    public GameObject m_ImageObject;

    public void ToggleCrossImage()
    {
        {
            if(m_ImageObject.activeSelf)
            {
                m_ImageObject.SetActive(false);
            }
            else
            {
                m_ImageObject.SetActive(true);
            }
        }
    }
}
