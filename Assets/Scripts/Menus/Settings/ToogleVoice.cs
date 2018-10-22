using UnityEngine;

public class ToogleVoice : MonoBehaviour {

    private AudioSource m_Source;

    public bool m_IsMuted;

    public World_Config m_Config;

    // Use this for initialization
    void Awake ()
    {
        // Get Audiosource
        m_Source = GetComponent<AudioSource>();

        // Get Config Data
        m_Config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();

        // Set AudioSource to saved mute status
        m_Source.mute = m_IsMuted;

         
    }

    private void PlayerSettings_VoiceOn(bool _status)
    {
        m_Source.mute = _status;
    }

    private void OnDestroy()
    {
        PlayerSettings.VoiceOn -= PlayerSettings_VoiceOn;
    }
}
