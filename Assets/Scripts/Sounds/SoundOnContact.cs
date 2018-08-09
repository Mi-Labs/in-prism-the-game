using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundOnContact : MonoBehaviour {

    [Space]
    public AudioClip m_Soundeffect;
    [Range(0.1f, 2)]
    public float m_MoreBoundingVolume;

    private AudioSource m_Audiodata;
    private BoxCollider2D m_BoxCollider;


    private void Start()
    {
        m_BoxCollider = gameObject.GetComponent<BoxCollider2D>();

        if (gameObject.GetComponent<AudioSource>() == null)
        {
            m_Audiodata = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            m_Audiodata = gameObject.GetComponent<AudioSource>();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_Audiodata.clip = m_Soundeffect;
        m_BoxCollider.bounds.Expand(m_MoreBoundingVolume);
        m_Audiodata.Play();
    }
}
