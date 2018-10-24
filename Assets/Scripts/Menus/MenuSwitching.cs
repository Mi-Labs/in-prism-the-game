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

    /// <summary>
    /// This method switch the canvas to powerUp
    /// </summary>
    public void SwitchToPowerUpCanvas()
    {
        SwitchCanvas(false, false, true);
        m_currentlyActiv = m_PowerUpMenuCanvas;
    }

    /// <summary>
    /// This method switch all the canvas
    /// </summary>
    /// <param name="_settings">If settings are aktive</param>
    /// <param name="_statistics">If statistics are aktive</param>
    /// <param name="_powerUp">If powerUp are aktive</param>
    private void SwitchCanvas(bool _settings, bool _statistics, bool _powerUp)
    {
        m_SettingCanvas.SetActive(_settings);
        m_StatisticsCanvas.SetActive(_statistics);
        m_PowerUpMenuCanvas.SetActive(_powerUp);
    }

    /// <summary>
    /// This method activates or deactives the menu
    /// </summary>
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
