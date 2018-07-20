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

        public void ToogleLevelPanel(int _levelnumber)
        {
            // If Level panel is active and is called from the same button
            if (m_Panel.activeSelf && _levelnumber == m_Acutallevelnumber)
            {
                m_Panel.SetActive(false);
            }
            else
            {
                // Save the wanted level
                m_Acutallevelnumber = _levelnumber;

                // Set teh Panel active
                m_Panel.SetActive(true);

                // Change the displayed text
                m_Panel.GetComponentInChildren<Text>().text = GetLevelText(_levelnumber);

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

        /// <summary>
        /// This method generates the level infos displayed on the panel
        /// </summary>
        /// <param name="_levelnumber"></param>
        /// <returns></returns>
        private string GetLevelText(int _levelnumber)
        {
            string leveltext = string.Empty;
            string worldtext = string.Empty;

            if (_levelnumber < 5)
            {
                worldtext = "World Ocean";
            }
            else if (_levelnumber > 4 && _levelnumber < 10)
            {
                worldtext = "World Desert";
            }
            else if (_levelnumber > 9 && _levelnumber < 15)
            {
                worldtext = "World Jungle";
            }
            else if (_levelnumber > 14 && _levelnumber < 20)
            {
                worldtext = "World Forest";
            }
            else if (_levelnumber > 19 && _levelnumber < 25)
            {
                worldtext = "World Underground";
            }
            else if (_levelnumber > 24 && _levelnumber < 30)
            {
                worldtext = "World Vulcan";
            }
            else
            {
                worldtext = "Night World";
            }

            // Generate the level number depending on the current world
            if (_levelnumber < 5)
            {
                leveltext = GenerateLevelText(_levelnumber, 4);
            }
            else if (_levelnumber > 29)
            {
                leveltext = GenerateLevelText((_levelnumber-5), 7);
            }
            else
            {
                leveltext = GenerateLevelText((_levelnumber-4), 5);
            }

            return worldtext + "\n" + leveltext;

        }

        void LevelStart(string _params)
        {
            Debug.Log(_params);
            controller.GetComponent<SceneManagerMenuScene>().ChooseLevel(_params);
        }

        private string GenerateLevelText(int _levelnumber, int _NumberOfLevels)
        {
            return "Level " + _levelnumber % (_NumberOfLevels + 1);
        }
    }

}
