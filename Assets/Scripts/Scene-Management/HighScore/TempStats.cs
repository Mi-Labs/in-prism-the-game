using UnityEngine;
using System;

namespace HighScore
{
    public class TempStats : MonoBehaviour
    {

        public int m_ActualLevelNumber;

        public float m_leveltime;

        public int m_NumberofDeaths;

        public int m_SavedSpheres;

        public string GenerateHighScoreStats()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(m_leveltime);

            string timeText = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            return "Leveltime: " + timeText + "\n" + "Saved Spheres: " + m_SavedSpheres + "\n" + "Deaths: " + m_NumberofDeaths;
        }

        public void EraseTempStats()
        {
            m_leveltime = 0.0f;
            m_NumberofDeaths = 0;
            m_SavedSpheres = 0;
        }

        public void SaveLevelStats(int _level,float _time,int _deaths,int _spheres)
        {
            m_ActualLevelNumber = _level;
            m_leveltime = _time;
            m_NumberofDeaths = _deaths;
            m_SavedSpheres = _spheres;
        }
    }
}

