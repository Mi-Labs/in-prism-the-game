using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace StartMenu
{
    public class StartmenuCanvasShowing : MonoBehaviour
    {
        
        [Header("Menu Buttons Reversed Order")]
        public Button[] m_Menubuttons;

        public int m_HighestWorldLevel;

        private int m_HighestLevelNumber;

        private World_Config m_Config;

        // Use this for initialization
        void Start()
        {
            m_HighestLevelNumber = GameObject.FindGameObjectWithTag("LevelSave").GetComponent<WorldObjectSave>().GetHighestLevelNumber();

        }

        public void ShowAvailableLevel()
        {
            if(!m_Config.m_AdminMode)
            {
                if (m_HighestWorldLevel < m_HighestLevelNumber)
                {
                    for(int i=0; i < m_Menubuttons.Length;i++)
                    {
                        
                    }
                }
            }
            else
            {
                foreach(Button button in m_Menubuttons)
                {
                    button.gameObject.SetActive(true);
                }
            }

        }
    }
}

