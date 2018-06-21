using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script provided by Tobias Schwandt M.Sc

namespace GameManagement
{
    public class SceneManagerMenuScene : SceneManagerScene
    {
        public void SwitchToPlay()
        {
            m_Manager.SwitchToScene(Manager.EScene.Play);
        }

        public void SwitchToLevel(int _SceneId)
        {
            m_Manager.SwitchToScene(_SceneId);
        }

        /// <summary>
        /// This method quits the games
        /// </summary>
        public void LeaveGame()
        {
            Application.Quit();
        }
    }

}
