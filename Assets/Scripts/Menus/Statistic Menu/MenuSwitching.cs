using UnityEngine;

public class MenuSwitching : MonoBehaviour {

    /* Fields */

    public GameObject m_StatisticsCanvas;

    public GameObject m_PowerUpMenuCanvas;

    public GameObject m_SettingCanvas;

    /* Methods */


    /// <summary>
    /// This method switch the canvas to settings
    /// </summary>
    public void SwitchToSettingsCanvas()
    {
        m_PowerUpMenuCanvas.SetActive(false);
        m_StatisticsCanvas.SetActive(false);
        m_SettingCanvas.SetActive(true);
    }

    /// <summary>
    /// This method switch the canvas to statistics
    /// </summary>
    public void SwitchToStatisticsCanvas()
    {
        m_SettingCanvas.SetActive(false);
        m_PowerUpMenuCanvas.SetActive(false);
        m_StatisticsCanvas.SetActive(true);
    }
}
