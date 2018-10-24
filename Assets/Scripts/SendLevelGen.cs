using System;
using UnityEngine;

public class SendLevelGen : MonoBehaviour {

    public static event Action<GameObject> LevelGen = delegate { };
    private GameObject m_LevelGen;

	// Use this for initialization
	void Start ()
    {
        m_LevelGen = GameObject.FindGameObjectWithTag("LevelGenerator");
        if(m_LevelGen != null)
        {
            OnLevelGen(m_LevelGen);
        }        
	}
	

    public void OnLevelGen(GameObject _obj)
    {
        if(LevelGen != null)
        {
            LevelGen(_obj);
        }
    }

}
