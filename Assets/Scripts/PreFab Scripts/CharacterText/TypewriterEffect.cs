using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour {

    public Text m_Textbox;

    public string[] m_ShownText;

    public float m_TimeToNextText;

    private int m_CurrentDisplayedText;

    IEnumerator AnimateText()
    {
        for (int i=0; (i < m_ShownText[m_CurrentDisplayedText].Length +1);i++)
        {
            m_Textbox.text = m_ShownText[m_CurrentDisplayedText].Substring(0, i);
            yield return new WaitForSeconds(m_TimeToNextText);
        }
    }


	// Use this for initialization
	void Start ()
    {
        m_CurrentDisplayedText = 0;
	}

    public void StartText()
    {
        StartCoroutine(AnimateText());
    }

	public void SkipToNextText()
    {
        StopAllCoroutines();
        m_CurrentDisplayedText++;

        if(m_CurrentDisplayedText > m_ShownText.Length)
        {
            ToggleTextCanvas.ToogleTextCanvas();
        }
        StartCoroutine(AnimateText());
    }

}
