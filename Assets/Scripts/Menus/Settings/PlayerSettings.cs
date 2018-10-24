using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerSettings : MonoBehaviour {

    private World_Config m_config;

    public static event Action<bool> MusicOn = delegate { };
    public static event Action<bool> VoiceOn = delegate { };
    public static event Action<bool> ControlOn = delegate { };

    private void Awake()
    {
        m_config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();

        if(!PlayerPrefs.HasKey("music"))
        {
            // Generate Key for music
            PlayerPrefs.SetInt("music", 1);

            m_config.m_EnabledSounds = true;
        }
        else
        {
            if(PlayerPrefs.GetInt("music") == 0)
            {
                m_config.m_EnabledSounds = false;
            }
            else
            {
                m_config.m_EnabledSounds = true;
            }
        }

         // Register Player prefs for controls
        if(!PlayerPrefs.HasKey("controls"))
        {
            PlayerPrefs.SetInt("controls", 1);
            m_config.m_InverseControls = true;
        }
        else
        {
            if (PlayerPrefs.GetInt("controls") == 0)
            {
                m_config.m_InverseControls = false;
            }
            else
            {
                m_config.m_InverseControls = true;
            }
        }
        if(!PlayerPrefs.HasKey("voice"))
        {
            PlayerPrefs.SetInt("voice", 1);
            m_config.m_EnabledVoice = true;
        }
        else
        {
            if (PlayerPrefs.GetInt("voice") == 0)
            {
                m_config.m_EnabledVoice = false;
            }
            else
            {
                m_config.m_EnabledVoice = true;
            }
        }

        PlayerPrefs.Save();

    }

    /// <summary>
    /// This methods toogle the game music
    /// </summary>
    public void ToogleMusic()
    {
          if(PlayerPrefs.GetInt("music") == 0)
        {
            PlayerPrefs.SetInt("music", 1);
            m_config.m_EnabledSounds = true;
            OnMusic(true);
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            m_config.m_EnabledSounds = false;
            OnMusic(false);
        }
        PlayerPrefs.Save();
    }

    /// <summary>
    /// This methods toogle the voice ingame
    /// </summary>
    public void ToogleVoice()
    {
        if (PlayerPrefs.GetInt("voice") == 0)
        {
            PlayerPrefs.SetInt("voice", 1);
            m_config.m_EnabledVoice = true;
            OnVoice(true);
        }
        else
        {
            PlayerPrefs.SetInt("voice", 0);
            m_config.m_EnabledVoice = false;
            OnVoice(false);
        }
        PlayerPrefs.Save();
    }

    /// <summary>
    /// This methods toogle inverse controls
    /// </summary>
    public void ToogleControls()
    {
        if (PlayerPrefs.GetInt("controls") == 0)
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

    public void OnMusic(bool status)
    {
        if (MusicOn != null)
        {
            MusicOn(status);
        }
    }

    /// <summary>
    /// This method sends an OnVoice event if the are eventhandlers listen
    /// </summary>
    /// <param name="status">Voice is muted</param>
    public void OnVoice(bool status)
    {
        if(VoiceOn != null)
        {
            VoiceOn(status);   
        }
    }

    /// <summary>
    /// This method sends an OnControl event if the are eventhandlers listen
    /// </summary>
    /// <param name="status">Controls are inverted</param>
    public void OnControl(bool status)
    {
        if(ControlOn != null)
        {
            ControlOn(status);
        }
    }
    
}