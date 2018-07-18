using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script provided by Tobias Schwandt M.Sc

namespace GameManagement
{
    public class SceneManagerMenuScene : SceneManagerScene
    {
        public void ChooseLevel(string _command)
        {
            string levelnumber = _command.Substring(0, 2);
            int level;
            int.TryParse(levelnumber, out level);
            string replaystring = _command.Substring(2, _command.Length-2);
            bool replay;
            bool.TryParse(replaystring, out replay);

            SwitchToLevel(level, replay);
        }

        public void SwitchToLevel(int _SceneId, bool _replaying)
        {
            m_Manager.SwitchToScene(_SceneId,_replaying);
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
