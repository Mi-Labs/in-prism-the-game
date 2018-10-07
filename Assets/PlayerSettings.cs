using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour {

    private World_Config m_config;

    public Toggle m_SoundToogle;
    public Toggle m_VoiceToogle;
    public Toggle m_InverseControls;

    private void Awake()
    {
        m_config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();

        if(!PlayerPrefs.HasKey("music"))
        {
            // Generate Key for music
            PlayerPrefs.SetInt("music", 1);

            m_config.m_EnabledSounds = true;
            m_SoundToogle.isOn = true;
        }
        else
        {
            if(PlayerPrefs.GetInt("music") == 0)
            {
                m_config.m_EnabledSounds = false;
                m_SoundToogle.isOn = false;
            }
            else
            {
                m_config.m_EnabledSounds = true;
                m_SoundToogle.isOn = true;
            }
        }

         // Register Player prefs for controls
        if(!PlayerPrefs.HasKey("controls"))
        {
            PlayerPrefs.SetInt("controls", 1);
            m_config.m_InverseControls = true;
            m_InverseControls.isOn = true;
        }
        else
        {
            if (PlayerPrefs.GetInt("controls") == 0)
            {
                m_config.m_InverseControls = false;
                m_InverseControls.isOn = false;
            }
            else
            {
                m_config.m_InverseControls = true;
                m_InverseControls.isOn = true;
            }
        }
        if(!PlayerPrefs.HasKey("voice"))
        {
            PlayerPrefs.SetInt("voice", 1);
            m_config.m_EnabledVoice = true;
            m_VoiceToogle.isOn = true;
        }
        else
        {
            if (PlayerPrefs.GetInt("voice") == 0)
            {
                m_config.m_EnabledVoice = false;
                m_VoiceToogle.isOn = false;
            }
            else
            {
                m_config.m_EnabledVoice = true;
                m_VoiceToogle.isOn = true;
            }
        }

        PlayerPrefs.Save();
    }

    /// <summary>
    /// This methods toogle the game music
    /// </summary>
    public void ToogleMusic()
    {
        if(m_SoundToogle.isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            m_config.m_EnabledSounds = true;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            m_config.m_EnabledSounds = false;
        }
        PlayerPrefs.Save();
    }

    /// <summary>
    /// This methods toogle the voice ingame
    /// </summary>
    public void ToogleVoice()
    {
        if (m_VoiceToogle.isOn)
        {
            PlayerPrefs.SetInt("voice", 1);
            m_config.m_EnabledVoice = true;
        }
        else
        {
            PlayerPrefs.SetInt("voice", 0);
            m_config.m_EnabledVoice = false;
        }
        PlayerPrefs.Save();
    }

    /// <summary>
    /// This methods toogle inverse controls
    /// </summary>
    public void ToogleControls()
    {
        if (m_InverseControls.isOn)
        {
            PlayerPrefs.SetInt("controls", 1);
            m_config.m_InverseControls = true;
        }
        else
        {
            PlayerPrefs.SetInt("controls", 0);
            m_config.m_InverseControls = false;
        }
        PlayerPrefs.Save();
    }
}
