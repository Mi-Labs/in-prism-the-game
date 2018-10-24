using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HighScore
{
    public class ChangeTextField : MonoBehaviour
    {

        public bool m_StatsActive, m_LevelTextActive;

        [Space(20)]
        [Header("Active Stat")]
        public bool m_Time;
        public bool m_SavedSpheres;
        public bool m_Deaths;
        public bool m_PlayedLevels;

        private Text m_Text;

        private TempStats m_temp;

        
        // Use this for initialization
        void Start()
        {
            m_Text = gameObject.GetComponent<Text>();
            m_temp = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TempStats>();

            if(m_StatsActive)
            {
                // If the text field is for the required time
                if(m_Time)
                {
                    m_Text.text = m_temp.GenerateLevelTimeStats();
                }
                // If the text field is for the saved spheres
                if (m_SavedSpheres)
                {
                    m_Text.text = m_temp.GenerateSavedSphereText();
                }
                // If the text field is for the deaths in this level
                if(m_Deaths)
                {
                    m_Text.text = m_temp.GenerateDeathText();
                }
                // If the text field is for the already played level
                if(m_PlayedLevels)
                {
                    // Get actual Levelnumber -3 
                }

         
            }
            else if(m_LevelTextActive)
            {
                m_Text.text = LevelTextGenerator.GetLevelText(m_temp.m_ActualLevelNumber);
            }
            else
            {
                Debug.Log("No text field is active");
            }
        }
    }
}

