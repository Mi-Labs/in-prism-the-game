using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;


public class LevelChoose : MonoBehaviour {

    /* Fields */

    private Dropdown m_WorldDropdown;

    private Dropdown m_LevelDropdown;

    private SceneManagerMenuScene m_MenuManager;


    /* Methods */

    void Start ()
    {
        // Find all dropdown menus and assign them
        Dropdown[] menues = gameObject.GetComponentsInChildren<Dropdown>();
        foreach(Dropdown menu in menues)
        {
            if(menu.gameObject.name.Contains("World"))
            {
                m_WorldDropdown = menu;
            }
            else if(menu.gameObject.name.Contains("Level"))
            {
                m_LevelDropdown = menu;
            }
        }

        // Find SceneMenuManager
        m_MenuManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneManagerMenuScene>();
    }


    ///// <summary>
    ///// This method starts the choosen level
    ///// </summary>
    //public void StartLevel()
    //{
    //    int chooselevel = 0;

    //    // Get the world number
    //    switch(m_WorldDropdown.value)
    //    {
    //        // Ocean
    //        case 0:
    //            chooselevel = 3;
    //            break;

    //        // Desert
    //        case 1:
    //            chooselevel = 7;
    //            break;

    //        // Jungle
    //        case 2:
    //            chooselevel = 12;
    //            break;
            
    //        // Forest
    //        case 3:
    //            chooselevel = 17;
    //            break;

    //        // Underground
    //        case 4:
    //            chooselevel = 22;
    //            break;

    //        // Vulcan
    //        case 5:
    //            chooselevel = 27;
    //            break;

    //        // Night
    //        case 6:
    //            chooselevel = 32;
    //            break;

    //        default:
    //            Debug.Log("Invalid input");
    //            break;
    //    }
    //    // Add single levelnumber
    //    chooselevel += m_LevelDropdown.value;

    //    // Switch to the level
    //    m_MenuManager.SwitchToLevel(chooselevel);
    //}
}
