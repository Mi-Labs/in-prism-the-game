using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManagement 
{
    public class SceneManagerPlayScene : SceneManagerScene
    {

        public void SwitchToMenu()
        {
            LoadScene(Manager.EScene.Menu);
        }

        public void ResetScene()
        {
            int buildindex = SceneManager.GetActiveScene().buildIndex;
            LoadScene(buildindex, true);
        }

        public void LoadScene(int _Scene)
        {
            LoadScene(_Scene, false);
        }

        public void SwitchToHighScore()
        {
            LoadScene(Manager.EScene.HighScore);
        }

        public void SwitchToCredits()
        {
            LoadScene(Manager.EScene.Credits);
        }
    }

}
