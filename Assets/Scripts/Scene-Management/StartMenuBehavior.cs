using System.Collections.Generic;
using UnityEngine;

public class StartMenuBehavior : MonoBehaviour {

    public GameObject m_Ocean;

    public GameObject m_Desert;

    public GameObject m_Jungle;

    public GameObject m_Forest;

    public GameObject m_Underground;

    public GameObject m_Vulcan;

    public World m_actualWorld;

    public enum World : int
    {
        NotSet = 0,
        Ocean = 1,
        Desert = 2,
        Jungle =3,
        Forest = 4,
        Underground =5,
        Vulcan = 6
    }

    public void SwitchToWorld(int _world)
    {
        m_actualWorld = GetActualWorldCanvas();
        if(_world >0 && _world <7 && _world != (int)m_actualWorld)
        {
            switch (_world)
            {
                case 1:
                    m_Ocean.SetActive(true);

                    if (m_Desert.activeSelf)
                    {
                    
                        m_Desert.SetActive(false);
                    } 
                    break;

                case 2:

                    m_Desert.SetActive(true);

                    if (m_Ocean.activeSelf)
                    {
                        m_Ocean.SetActive(false);
                    }
                    else if(m_Jungle.activeSelf)
                    {
                        m_Jungle.SetActive(false);                 
                    }
                    break;

                case 3:

                    m_Jungle.SetActive(true);

                    if (m_Desert.activeSelf)
                    {
                        m_Desert.SetActive(false);
                    }
                    else if (m_Forest.activeSelf)
                    { 
                        m_Forest.SetActive(false);
                    }
                    break;

                case 4:

                    m_Forest.SetActive(true);

                    if (m_Jungle.activeSelf)
                    { 
                        m_Jungle.SetActive(false);
                    }
                    else if (m_Underground.activeSelf)
                    {
                        m_Underground.SetActive(false);

                    }
                    break;

                case 5:

                    m_Underground.SetActive(true);

                    if (m_Forest.activeSelf)
                    {
                        m_Forest.SetActive(false);
                    }
                    else if (m_Vulcan.activeSelf)
                    {
                        m_Underground.SetActive(true);
                        m_Vulcan.SetActive(false);

                    }
                    break;

                case 6:
                    m_Vulcan.SetActive(true);

                    if (m_Underground.activeSelf)
                    {
                        m_Underground.SetActive(false);
                    }
                    break;

                default:
                    break;
            }
           
            
        }
    }

    public World GetActualWorldCanvas()
    {
        World actualWorld = World.NotSet;

        string[] loaded_canvas = new string[6];

        Canvas[] activeCanvas = gameObject.GetComponentsInChildren<Canvas>();

        for(int i=0; i < activeCanvas.Length; i++)
        {
            loaded_canvas[i] = activeCanvas[i].gameObject.name;
        }
        
        for(int i=0; i< loaded_canvas.Length; i++)
        {
            actualWorld = GetActualWorld(loaded_canvas[i]);
        }

        return actualWorld;

    }

	
    private World GetActualWorld(string _world)
    {
        World actualWorld = World.NotSet;
        switch (_world)
        {
            case "Ocean":
                actualWorld = World.Ocean;
                break;

            case "Desert":
                actualWorld = World.Desert;
                break;

            case "Jungle":
                actualWorld = World.Jungle;
                break;

            case "Forest":
                actualWorld = World.Forest;
                break;

            case "Underground":
                actualWorld = World.Underground;
                break;

            case "Vulcan":
                actualWorld = World.Vulcan;
                break;

            default:
                break;
        }
        return actualWorld;

    }

    
    
}
