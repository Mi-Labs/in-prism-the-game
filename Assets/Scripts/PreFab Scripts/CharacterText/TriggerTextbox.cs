using UnityEngine;

public class TriggerTextbox : MonoBehaviour {

    /* Fields */

    public string[] m_text;

    private World_Config m_Config;


    /* Methods */

    private void Start()
    {
        m_Config = GameObject.FindGameObjectWithTag("Config").GetComponent<World_Config>();
    }

    /// <summary>
    /// This method is called, if the trigger attached to this GO is activated
    /// </summary>
    /// <param name="_collision"></param>
    private void OnTriggerEnter2D(Collider2D _collision)
    {
        // If the player activates the trigger
        if(_collision.gameObject.CompareTag("Player"))
        {
            // Show the text panel
            ShowTextBox();

            // Show the attached text
            ShowText();
        }
    }


    /// <summary>
    /// This method shows the textpanel
    /// </summary>
    private void ShowTextBox()
    {
        m_Config.m_TextCanvas.GetComponent<ToogleTextPanel>().TooglePanel();
        
    }
    /// <summary>
    /// This method sends the attached text to the panel and starts the typewriter effect
    /// </summary>
    private void ShowText()
    {
        m_Config.m_TextCanvas.GetComponentInChildren<TypewriterEffect>().StartText(m_text);
    }
}
