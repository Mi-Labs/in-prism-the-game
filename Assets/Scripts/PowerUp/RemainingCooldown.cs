using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingCooldown : MonoBehaviour {

    private Image m_WhiteCircle;

	// Use this for initialization
	void Start ()
    {
        m_WhiteCircle = gameObject.GetComponentInChildren<Image>();


        if(m_WhiteCircle != null)
        {
            m_WhiteCircle.fillAmount = 0.0f;
        }
        else
        {
            Debug.Log("LoadingCircle not found");
        }
	}

    IEnumerator CoolDownGraphic(int _time)
    {
        float steps = (float)_time / Time.deltaTime;
        float drawStep = 360.0f / steps;

        for(float i=0.0f;i < steps; i++)
        {
            m_WhiteCircle.fillAmount -= drawStep;
            yield return null;
        }
         
        yield return null;
    }

    public void StartCoolDownGraphic(int _time)
    {
        // Set Filling to maximum
        m_WhiteCircle.fillAmount = 1.0f;
        StartCoroutine(CoolDownGraphic(_time));
    }
	

}
