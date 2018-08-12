using UnityEngine;
using UnityEngine.UI;
using GameManagement;

namespace StartMenu
{
    public class PanelToogle : MonoBehaviour
    {
        public GameObject m_Panel;

        public GameObject controller;

        private int m_Acutallevelnumber;


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

        public void ToogleLevelPanel(int _levelnumber)
        {
            // If Level panel is active and is called from the same button
            if (m_Panel.activeSelf && _levelnumber == m_Acutallevelnumber)
            {
                Debug.Log("Closed LevelPanel");
                m_Panel.SetActive(false);
            }
            else
            {
                // Save the wanted level
                m_Acutallevelnumber = _levelnumber;

                // Set the Panel active
                m_Panel.SetActive(true);

                // Change the displayed text
                m_Panel.GetComponentInChildren<Text>().text = LevelTextGenerator.GetLevelText(_levelnumber);

                // Find all buttons on the panel
                Button[] buttons = m_Panel.GetComponentsInChildren<Button>();

                // Generate the scene number to load
                int choosenumber = _levelnumber + 2;
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
                foreach (Button button in buttons)
                {
                    // Add Eventlistener to Start button
                    if (button.gameObject.name.Equals("Start"))
                    {
                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(delegate { LevelStart(chooseLevel + "false"); });
                    }
                    else if (button.gameObject.name.Equals("Replay"))
                    {
                        button.onClick.RemoveAllListeners();
                        button.onClick.AddListener(delegate { LevelStart(chooseLevel + "true"); });
                    }
                }
            }
        }
     

        private void LevelStart(string _params)
        {
            controller.GetComponent<SceneManagerMenuScene>().ChooseLevel(_params);
        }

    }

}
