using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleMusic : MonoBehaviour {

    private AudioSource m_Source;

    public bool m_IsMuted;

    public World_Config m_Config;

    private void Awake()
    {
        m_Source = GetComponent<AudioSource>();

        m_Config = GameObject.FindGameObjectWithTag("Config").GetComponent
    }
}
