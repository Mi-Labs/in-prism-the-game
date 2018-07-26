using UnityEngine;
using GameManagement;

namespace HighScore
{
    public class SwitchToHighScore : MonoBehaviour
    {
        private TempStats m_temp;

        private Level_Stats m_stats;

        private GameObject m_Controller;

        private void Start()
        {
            m_temp = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TempStats>();
            m_Controller = GameObject.FindGameObjectWithTag("GameController");
            m_stats =m_Controller.GetComponent<Level_Stats>();
        }

        private void OnTriggerEnter2D(Collider2D _collision)
        {
            if(_collision.gameObject.CompareTag("Player"))
            {
                // Save Data in temp data
                m_temp.EraseTempStats();

                m_temp.SaveLevelStats(m_stats.GetLevelNumber(), m_stats.GetLevelTime(), m_stats.GetNumberOfDeaths(), m_stats.GetNumberOfSavedSpheres());

                m_Controller.GetComponent<SceneManagerPlayScene>().SwitchToHighScore();
            }
        }
    }
}

