using UnityEngine;
using UnityEngine.UI;

public class ToggleMenuCircles : MonoBehaviour {

    private Image m_MainCircleRenderer;

    public Sprite m_InverseCircle;
    public Sprite m_NormalCircle;

    private World_Config m_Config;

    public void Start()
    {
        m_Config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();
        m_MainCircleRenderer = gameObject.GetComponent<Image>();
    }

    /// <summary>
    /// This method changes the sprite for the circle
    /// </summary>
    public void  ToogleCircle()
    {
        if(m_Config.m_InverseControls)
        {
            m_MainCircleRenderer.sprite = m_InverseCircle;
        }
        else
        {
            m_MainCircleRenderer.sprite = m_NormalCircle;
        }
        
    }
}
