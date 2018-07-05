using UnityEngine;
using System.IO;

public class JSONSerializer : MonoBehaviour {

    public string m_filePath;

    public WorldLevelGO m_gameSave;

    public void Awake()
    {
        m_filePath = Application.persistentDataPath +"savegame.json";
        m_gameSave = GameObject.FindGameObjectWithTag("LevelSave").GetComponent<WorldLevelGO>();  
    }

    public void Serialize()
    {
        string jsonString = JsonUtility.ToJson(m_gameSave, true);
        File.WriteAllText(m_filePath, jsonString);
        Debug.Log("File serialized");
    }

    public void DeSerialize()
    {
        string jsonString = File.ReadAllText(m_filePath);
        m_gameSave = JsonUtility.FromJson<WorldLevelGO>(jsonString);
    }
}
