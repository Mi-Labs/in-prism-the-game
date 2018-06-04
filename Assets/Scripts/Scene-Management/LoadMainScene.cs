using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour {

    private static System.String m_ActualLevelName;

	IEnumerator AscynchronusGameLevelLoad(System.String _scene)
    {
        yield return null;

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(_scene,LoadSceneMode.Additive);
        asyncOp.allowSceneActivation = false;

        while(!asyncOp.isDone)
        {
            float progress = Mathf.Clamp01(asyncOp.progress / 0.9f);
            //Debug.Log("Loading progress: " + (progress * 100) + "%");

            if(asyncOp.progress == 0.9f)
            {
                asyncOp.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    IEnumerator AsyncronusExtraScencesLoad(System.String _name)
    {
        yield return null;

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(_name, LoadSceneMode.Additive);
            
        asyncOp.allowSceneActivation = false;

        while (!asyncOp.isDone)
        {
            if (asyncOp.progress == 0.9f)
            {
            //Debug.Log("Scene loaded");
            asyncOp.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    public void LoadGameScene(System.String _scene)
    {
        if(_scene.Contains("Level"))
        {
            StartCoroutine(AscynchronusGameLevelLoad(_scene));
            m_ActualLevelName = _scene;
            Debug.Log(m_ActualLevelName);
        }       
        else
        {
            Debug.LogError("Incorrect Scene name input");
        }
    }

    public void LoadTestLevel()
    {
        if(SceneManager.GetSceneByName("Level 00-Test") != null)
        {
            LoadExtraScences();
            LoadGameScene("Level 00-Test");
        }
        
    }

    public void UnloadScence(System.String _scene)
    {
        SceneManager.UnloadSceneAsync(_scene);
    }

    public void ResetLevel()
    {
        UnloadScence(m_ActualLevelName);
        SceneManager.LoadScene(m_ActualLevelName, LoadSceneMode.Additive);
        
    }

    private void LoadExtraScences()
    {
        StartCoroutine(AsyncronusExtraScencesLoad("LifeCanvas"));
        StartCoroutine(AsyncronusExtraScencesLoad("PowerUpMenu"));
    }
}
