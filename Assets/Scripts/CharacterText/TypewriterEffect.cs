using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Idea by https://answers.unity.com/questions/676760/scrolling-typewriter-effect.html

public class TypewriterEffect : MonoBehaviour {

    /* Fields */

    // Field for the text to show up
    public Text m_Textbox;

    // Field for wait time after text is finished
    public float m_ExtraWaitTime;

    // Field for the content -> text and sound
    private TextSpeech[] m_Content;

    private float m_TimeToNextText;

    private int m_CurrentDisplayedText;

    private World_Config m_config;

    private AudioSource m_Audiosource;

    /* IEnumators */
   
    IEnumerator AnimateText()
    {
        m_Audiosource.clip = m_Content[m_CurrentDisplayedText].GetAudio();

        m_TimeToNextText = m_Content[m_CurrentDisplayedText].GetAudio().length /m_Content[m_CurrentDisplayedText].GetText().Length;

        m_Audiosource.Play(); 
        // For every char in the textline
        for (int i=0; i < m_Content[m_CurrentDisplayedText].GetText().Length; i++)
        {
            // Debug.Log("Length string: " +m_ShownText[m_CurrentDisplayedText].Length);

            // Show all chars till the actual char in this string
            m_Textbox.text = m_Content[m_CurrentDisplayedText].GetText().Substring(0, i);

            // Wait till the next char should be shown
            yield return new WaitForSeconds(m_TimeToNextText);
        }
        yield return new WaitForSeconds(m_ExtraWaitTime);
        SkipToNextText();
    }


    /* Methods */

    void Start ()
    {
        if(m_Audiosource == null)
        {
            m_Audiosource = gameObject.AddComponent<AudioSource>();
        }
        m_CurrentDisplayedText = 0;
        m_config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();
        m_TimeToNextText = m_config.m_Textspeed;
        m_Textbox = gameObject.GetComponent<Text>();
    }

    /// <summary>
    /// This method starts the typewriter effect on the textpanel
    /// </summary>
    /// <param name="_text">All text, that should be displayed</param>
    public void StartText(TextSpeech[] _text)
    {
        // Initalize the Script
        Start();

        // Safety Check ! -> If Input is null -> Error
        if(_text != null)
        {
            // Save input
            m_Content = _text;

            // Start typewriter effect
            StartCoroutine(AnimateText());
        }
        else
        {
            Debug.LogError("No text to display!");
        }
    }


    /// <summary>
    /// This method skips the remaining text and goes for the next line
    /// </summary>
	public void SkipToNextText()
    {
        // Stop actual text from showing
        StopAllCoroutines();

        // Go to next text line
        m_CurrentDisplayedText++;

        // If there is no next textline, deactivate the text panel ...
        if(m_CurrentDisplayedText >= m_Content.Length)
        {
            m_config.m_TextCanvas.GetComponent<ToogleTextPanel>().SetPanel(false);
            m_Audiosource.Stop();
        }
        // Else show next textline
        else
        {
            StartCoroutine(AnimateText());
        }  
    }
}
