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
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

}
