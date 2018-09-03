using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpeech{

    [SerializeField]
    private AudioClip m_Audio;

    [SerializeField]
    private string m_Text;

    public string GetText()
    {
        return m_Text;
    }

    public AudioClip GetAudio()
    {
        return m_Audio;
    }

}
