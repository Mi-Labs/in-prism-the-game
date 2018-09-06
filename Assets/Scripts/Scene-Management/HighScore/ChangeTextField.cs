using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HighScore
{
    public class ChangeTextField : MonoBehaviour
    {

        public bool m_StatsActive, m_LevelTextActive;

        private Text m_levelText;

        private TempStats m_temp;

        
        // Use this for initialization
        void Start()
        {
            m_levelText = gameObject.GetComponent<Text>();
            m_temp = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TempStats>();

            if(m_StatsActive)
            {
                m_levelText.text = m_temp.GenerateHighScoreStats();
            }
            else if(m_LevelTextActive)
            {
                m_levelText.text = LevelTextGenerator.GetLevelText(m_temp.m_ActualLevelNumber);
            }
            else
            {
                Debug.Log("No text field is active");
            }
        }
    }
}

