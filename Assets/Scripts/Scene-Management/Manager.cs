using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameManagement;

// Script provided by Tobias Schwandt M.Sc

namespace GameManagement
{
    public class Manager : MonoBehaviour
    {
        /* Fields */
        [SerializeField]
        private EScene m_CurrentScene = 0;
        [SerializeField]
        private EScene m_NextScene = 0;
        



        public enum EScene : int
        {
            Menu = 0,
            Play, NumberOfScenes,Base = -1
        };


        /* IEnumators */

        IEnumerator OnTransition(EScene _NewState)
        {
            AsyncOperation LoadScene;

            LoadScene = SceneManager.UnloadSceneAsync((int)m_CurrentScene);

            m_CurrentScene = _NewState;

            yield return LoadScene;

            LoadScene = SceneManager.LoadSceneAsync((int)m_CurrentScene, LoadSceneMode.Additive);

            yield return LoadScene;

            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)m_CurrentScene));
        }


        /* Methods */

        void Start()
        {
            if (m_CurrentScene == EScene.Base)
            {
                m_CurrentScene = m_NextScene;

                SceneManager.LoadScene((int)m_NextScene, LoadSceneMode.Additive);

                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)m_NextScene));
            }
        }


        // Update is called once per frame
        void Update()
        {
            if(m_NextScene != m_CurrentScene)
            {
                StartCoroutine(OnTransition(m_NextScene));
            }
        }


        public void SwitchToScene(EScene _Scene)
        {
            if (_Scene >= 0 && _Scene < EScene.NumberOfScenes)
            {
                m_NextScene = _Scene;
            }
        }

        // -----------------------------------------------------------------------------

        public void SwitchToScene(int _SceneID)
        {
            SwitchToScene((Manager.EScene)_SceneID);
        }

        /// <summary>
        /// This method quits the game
        /// </summary>
        public void Quit()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
        #endif
        }
    }
}
