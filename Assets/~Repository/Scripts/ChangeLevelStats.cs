using UnityEngine;
using UnityEngine.UI;

namespace HighScore
{
    public class ChangeLevelStats : MonoBehaviour
    {
        private Text m_levelstats;

        private TempStats m_temp;

        // Use this for initialization
        void Start()
        {
            m_levelstats = gameObject.GetComponent<Text>();
            m_temp = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TempStats>();

            m_levelstats.text = m_temp.GenerateHighScoreStats();

        } 
    }
}

