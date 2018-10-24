using UnityEngine;
using UnityEngine.UI;
using GameManagement;

namespace StartMenu
{
    public class PanelToogle : MonoBehaviour
    {
        public GameObject m_Panel;

        public GameObject controller;

        public Button m_ReplayButton, m_StartButton;

        private int m_Acutallevelnumber;

        private int m_HighestNumber;

        /// <summary>
        /// This method closes the level panel
        /// </summary>
        public void CloseLevelPanel()
        {
            if(m_Panel.activeSelf)
            {
                m_Panel.SetActive(false);
            }
        }


        /// <summary>
        /// This method toogles the level panel with the given levelnumber
        /// </summary>
        /// <param name="_levelnumber"></param>
        public void ToogleLevelPanel(int _levelnumber)
        {
            // Get highest level number
            m_HighestNumber = GameObject.FindGameObjectWithTag("LevelSave").GetComponent<WorldObjectSave>().GetHighestLevelNumber();

            // If Level panel is active and is called from the same button
            if (_levelnumber == m_Acutallevelnumber)
            {
                CloseLevelPanel();
                m_Acutallevelnumber = 0;
            }
            else
            {
                // Save the wanted level
                m_Acutallevelnumber = _levelnumber;

                // Set the Panel active
                m_Panel.SetActive(true);

                // Change the displayed text
                m_Panel.GetComponentInChildren<Text>().text = LevelTextGenerator.GetLevelText(_levelnumber);

               
                if(m_Acutallevelnumber >= m_HighestNumber)
                {
                    m_ReplayButton.gameObject.SetActive(false);  
                }
                else
                {
                    m_ReplayButton.gameObject.SetActive(true);
                }

                // Generate the scene number to load
                int choosenumber = _levelnumber;
                string chooseLevel = string.Empty;
                if (choosenumber < 10)
                {
                    chooseLevel = "0" + choosenumber;
                }
                else
                {
                    chooseLevel = choosenumber.ToString();
                }

                // Add event listener to every button
                m_StartButton.onClick.RemoveAllListeners();
                m_StartButton.onClick.AddListener(delegate { LevelStart(chooseLevel + "false"); });
                m_ReplayButton.onClick.RemoveAllListeners();
                m_ReplayButton.onClick.AddListener(delegate { LevelStart(chooseLevel + "true"); });  
            }
        }
     

        private void LevelStart(string _params)
        {
            controller.GetComponent<SceneManagerMenuScene>().ChooseLevel(_params);
        }
    }
}
