using UnityEngine;

public class MenuSwitching : MonoBehaviour {

    /* Fields */

    public GameObject m_StatisticsCanvas;

    public GameObject m_PowerUpMenuCanvas;

    public GameObject m_SettingCanvas;

    public GameObject m_currentlyActiv;


    /// <summary>
    /// This method switch the canvas to settings
    /// </summary>
    public void SwitchToSettingsCanvas()
    {
        SwitchCanvas(true, false, false);
        m_currentlyActiv = m_SettingCanvas;
    }

    /// <summary>
    /// This method switch the canvas to statistics
    /// </summary>
    public void SwitchToStatisticsCanvas()
    {
        SwitchCanvas(false, true, false);
        m_currentlyActiv = m_StatisticsCanvas;
        m_StatisticsCanvas.GetComponent<LoadStatistics>().SetActualValues();
    }

    public void SwitchToPowerUpCanvas()
    {
        SwitchCanvas(false, false, true);
        m_currentlyActiv = m_PowerUpMenuCanvas;
    }

    private void SwitchCanvas(bool _settings, bool _statistics, bool _powerUp)
    {
        m_SettingCanvas.SetActive(_settings);
        m_StatisticsCanvas.SetActive(_statistics);
        m_PowerUpMenuCanvas.SetActive(_powerUp);
    }

    public void ToggleMenu()
    {
        if(m_currentlyActiv != null)
        {
            m_currentlyActiv = null;
            SwitchCanvas(false, false, false);
        }
        else
        {
            SwitchToPowerUpCanvas();
        }
    }
}
