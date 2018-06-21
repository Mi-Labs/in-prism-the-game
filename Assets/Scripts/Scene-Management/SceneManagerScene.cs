using UnityEngine;

// Script provided by Tobias Schwandt M.Sc

namespace GameManagement
{
    public class SceneManagerScene : MonoBehaviour
    {
        /* Fields */

        [TagSelector]
        public string m_ManagerTag;

        protected Manager m_Manager;


        /* Methods */

        // Use this for initialization
        void Awake()
        {
            m_Manager = GameObject.FindGameObjectWithTag(m_ManagerTag).GetComponentInChildren<Manager>();
        }

        public void LoadScene(int _SceneId)
        {
            m_Manager.SwitchToScene(_SceneId);
        }

        public void LoadScene(Manager.EScene _SceneId)
        {
            m_Manager.SwitchToScene(_SceneId);
        }
    }


}
