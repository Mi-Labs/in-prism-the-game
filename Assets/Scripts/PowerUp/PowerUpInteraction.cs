using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpInteraction : MonoBehaviour {


    /* Fields */

    private Button m_button;

    private Image m_image;

    private Image m_WhiteCircle;


    /* IEnumators */

    IEnumerator CoolDownGraphic(int _time)
    {
        float steps = (float)_time / Time.deltaTime;
        float drawStep = 360.0f / steps;

        for (float i = 0.0f; i < steps; i++)
        {
            m_WhiteCircle.fillAmount -= drawStep;
            yield return null;
        }
        yield return null;
    }


    /* Methods */

    void Start ()
    {
        // Get the button component of this GO
        m_button = gameObject.GetComponent<Button>();

        // Get the image component of this GO
        m_image = gameObject.GetComponent<Image>();

       // Get the loading circle in children
        m_WhiteCircle = gameObject.GetComponentInChildren<Image>();

        // If Loading Circle is found...
        if (m_WhiteCircle != null)
        {
            m_WhiteCircle.fillAmount = 0.0f;
        }
        else
        {
            Debug.Log("LoadingCircle not found");
        }
    }


    /// <summary>
    /// This method makes the image component on this GO visible
    /// </summary>
    public void MakePowerUpVisible()
    {
        // Debug.Log("Make Visible is called on " + gameObject.name);
        if(!m_image.enabled)
        {
            // Debug.Log("Image is enabled");
            m_image.enabled = true;
        }
    }


    /// <summary>
    /// This method toggles the interactibility of the button of this GO
    /// </summary>
    /// <param name="_status">True, if the button should be interactable</param>
    public void ToggleInteractibility (bool _status)
    {
        m_button.interactable = (_status) ? true : false;
    }


    /// <summary>
    /// This method starts the cooldown graphic depending on the cooldown-time
    /// </summary>
    /// <param name="_time">The cooldown-time</param>
    public void StartCoolDownGraphic(int _time)
    {
        // Set filling to max
        m_WhiteCircle.fillAmount = 1.0f;

        StartCoroutine(CoolDownGraphic(_time));
    }
}
