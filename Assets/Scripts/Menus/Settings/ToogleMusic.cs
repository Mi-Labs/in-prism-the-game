using UnityEngine;

public class ToogleMusic : MonoBehaviour {

    [SerializeField]
    private AudioSource m_Source;

    public bool m_IsMuted;

    public World_Config m_Config;

    private void Start()
    {
        // Get Audiosource
        m_Source = GetComponent<AudioSource>();

        // Get Config Data
        m_Config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();

        PlayerSettings.MusicOn += PlayerSettings_MusicOn;
    }

    /// <summary>
    /// This method handles the chancing events of muting
    /// </summary>
    /// <param name="_status">New mute status</param>
    private void PlayerSettings_MusicOn(bool _status)
    {
        Debug.Log(_status);
            m_Source.mute = !m_Source.mute;     
    }

    private void OnDestroy()
    {
        PlayerSettings.MusicOn -= PlayerSettings_MusicOn;
    }

}
