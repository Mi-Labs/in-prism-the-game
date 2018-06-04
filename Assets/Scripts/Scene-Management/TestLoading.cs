using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoading : MonoBehaviour {

    public bool m_testSceneLoaded = false;
	
	// Update is called once per frame
	void Update ()
    {
		if(!m_testSceneLoaded)
        {
            LoadMainScene script = this.GetComponent<LoadMainScene>();
            script.LoadTestLevel();
            m_testSceneLoaded = true;
        }
	}
}
