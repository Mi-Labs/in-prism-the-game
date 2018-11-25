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

        private bool m_RePlaying;

        private bool m_SceneIsLoaded;

        public enum EScene : int
        {
            Base = 0,            
            Menu = 1,
            StartLevel = 2,
            Ocean1 = 3,
            Ocean2 = 4,
            Ocean3 = 5,
            Ocean4 = 6,
            Desert1 =7,
            Desert2 = 8,
            Desert3 = 9,
            Desert4 = 10,
            Desert5 = 11,
            Jungle1 = 12,
            Jungle2 = 13,
            Jungle3 = 14,
            Jungle4 = 15,
            Jungle5 = 16,
            Forest1 = 17,
            Forest2 = 18,
            Forest3 = 19,
            Forest4 = 20,
            Forest5 = 21,
            Underground1 = 22,
            Underground2 = 23,
            Underground3 = 24,
            Underground4 = 25,
            Underground5 = 26,
            Vulcan1 = 27,
            Vulcan2 = 28,
            Vulcan3 = 29,
            Vulcan4 = 30,
            Vulcan5 = 31,
            Night1 = 32,
            Night2 = 33,
            Night3 = 34,
            Night4 = 35,
            Night5 = 36,
            Night6 = 37,
            Night7 = 38,
            HighScore = 39,
            Credits = 40,
            StartSceen = 41,
            NumberOfScenes = 42
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

            m_SceneIsLoaded = true;
        }


        /* Methods */

        void Start()
        {
            if (m_CurrentScene == EScene.Base)
            {
                m_CurrentScene = m_NextScene;

                AsyncOperation async;

                async = SceneManager.LoadSceneAsync((int)m_NextScene, LoadSceneMode.Additive);
                
                if(async.isDone)
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int) m_NextScene));
                }              
            }

            // Init variable
            m_RePlaying = false;
            m_SceneIsLoaded = false;
        }


        // Update is called once per frame
        void Update()
        {
            if(m_NextScene != m_CurrentScene)
            {
                StartCoroutine(OnTransition(m_NextScene));     
            }
            if (m_SceneIsLoaded)
            {
                GameObject levelgen = GameObject.FindGameObjectWithTag("LevelGenerator");
                if(levelgen != null)
                {
                    Level_Generator generator = levelgen.GetComponent<Level_Generator>();
                    if (m_RePlaying)
                    {
                        generator.LoadLevel(true);
                    }
                    else
                    {
                        generator.LoadLevel(false);
                    }
                }
               
                m_RePlaying = false;
                m_SceneIsLoaded = false;
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

        public void SwitchToScene(int _SceneID, bool _Replaying)
        {
            SwitchToScene((Manager.EScene)_SceneID);
            m_RePlaying = _Replaying;
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

        public EScene GetCurrentScene()
        {
            return m_CurrentScene;
        }
    }
}
