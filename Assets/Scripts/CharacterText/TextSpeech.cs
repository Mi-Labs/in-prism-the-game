using UnityEngine;

[System.Serializable]
public class TextSpeech{

    /* Fields */

    // Holds the audiodata
    [SerializeField]
    private AudioClip m_Audio;

    // Holds the textdata
    [SerializeField]
    private string m_Text;

    /* Methods */

    /// <summary>
    /// This method returns the text
    /// </summary>
    /// <returns>The saved text</returns>
    public string GetText()
    {
        return m_Text;
    }

    /// <summary>
    /// This method retuns the audio
    /// </summary>
    /// <returns>The saved audio clip</returns>
    public AudioClip GetAudio()
    {
        return m_Audio;
    }
}
