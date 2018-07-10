using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touched the end");
        

        LevelSave levelSave = new LevelSave();
        levelSave.FillColorList();

        WorldObjectSave worldObjectSave = GameObject.FindGameObjectWithTag("LevelSave").GetComponent<WorldObjectSave>();

        worldObjectSave.AddLevelSave(levelSave);


        BinarySerializer.Save(worldObjectSave.SaveData());
    }
}
