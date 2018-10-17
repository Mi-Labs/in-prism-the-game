using System.Collections;
using System.IO;
using UnityEngine;
using GameManagement;

public class GameStartUp : MonoBehaviour {

    private string m_Filepath;

    private SceneManagerPlayScene m_Controller;

	// Use this for initialization
	void Awake ()
    {
        m_Filepath = Path.Combine(Application.persistentDataPath, "game.save");
        m_Controller = GetComponent<SceneManagerPlayScene>();
	}
	

   public void StartGame()
    {
        // If there is an savegame
        if(File.Exists(m_Filepath))
        {
            m_Controller.SwitchToMenu();
        }
        else
        {
            m_Controller.LoadScene(2);
        }
    }
}
