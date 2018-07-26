using UnityEngine;

public class SaveLevelData : MonoBehaviour {

    /* Methods */
    
    /// <summary>
    /// Is called, when the box collider is triggered
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Create a new Level Save
        LevelSave levelSave = new LevelSave();

        // Save all changed colors
        levelSave.FillColorList();

        // Get WorldObjectSave Object
        WorldObjectSave worldObjectSave = GameObject.FindGameObjectWithTag("LevelSave").GetComponent<WorldObjectSave>();

        // Add Levelsave to WorldObjectSave
        worldObjectSave.AddLevelSave(levelSave);

        // Save Game
        BinarySerializer.SaveGame(worldObjectSave.SaveData());
    }
}
