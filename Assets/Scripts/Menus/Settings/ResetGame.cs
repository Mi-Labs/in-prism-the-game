using UnityEngine;
using System.IO;

public class ResetGame : MonoBehaviour {

    public string m_SavePath, m_StatsPath;

	// Use this for initialization
	void Start ()
    {
        m_SavePath = BinarySerializer.GetSaveGamePath();
        m_StatsPath = BinarySerializer.GetSaveStasticPath();
	}
	
	public void ResetGameData()
    {
        File.Delete(m_SavePath);
        File.Delete(m_StatsPath);
        Debug.Log("Deleted Files");
    }
}
