using UnityEngine;
using GameManagement;

namespace HighScore
{
    public class HighScoreController : MonoBehaviour
    {
        private TempStats m_Temp;

        private SceneManagerPlayScene m_ControlScript;

        private void Start()
        {
            m_Temp = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TempStats>();

            m_ControlScript = gameObject.GetComponent<SceneManagerPlayScene>();
        }

        public void ReplayLastLevel()
        {
            m_ControlScript.LoadScene(m_Temp.m_ActualLevelNumber);
            m_Temp.EraseTempStats();
        }

        public void PlayNextLevel()
        {
            if(m_Temp.m_ActualLevelNumber+1 <= 32)
            {
                m_ControlScript.LoadScene(m_Temp.m_ActualLevelNumber + 1);
                m_Temp.EraseTempStats();
            }
            else
            {
                m_ControlScript.SwitchToCredits();
            }
            
        }
    }
}

