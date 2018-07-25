using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTextbox : MonoBehaviour {

    private TypewriterEffect m_effect;

    private void Start()
    {
        m_effect = gameObject.GetComponent<TypewriterEffect>();
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if(_collision.gameObject.CompareTag("Player"))
        {
            ShowTextBox();
        }
    }

    private void ShowTextBox()
    {
        ToggleTextCanvas.ToogleTextCanvas();
        m_effect.StartText();
    }
}
