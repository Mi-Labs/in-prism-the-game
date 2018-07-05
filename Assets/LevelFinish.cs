using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touched the end");
        WorldLevelGO m_SaveGame = GameObject.FindGameObjectWithTag("LevelSave").GetComponent<WorldLevelGO>();

        m_SaveGame.m_IsSaving = true;

        JSONSerializer serializer = GameObject.FindGameObjectWithTag("JSONSerialize").GetComponent<JSONSerializer>();

        serializer.Serialize();
    }
}
