using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinarySerializer : MonoBehaviour {

    private static string m_FilePath; 

    private static WorldSave m_Save;

    // private static GlobalStatistics m_stats;

    private void Awake()
    {
        m_FilePath = Path.Combine(Application.persistentDataPath, "game.save");
        Debug.Log(m_FilePath);
    }

    public static void Save(WorldSave _save)
    {
        m_Save = _save;
        BinaryFormatter bf = new BinaryFormatter();
        SaveLevel(bf);
    }

    private static void SaveLevel(BinaryFormatter _bf)
    {
        if(m_Save != null)
        {
            using (FileStream stream = new FileStream(m_FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                _bf.Serialize(stream, m_Save);
            }
            Debug.Log("Level serialized");
        }
    }

    public static void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();

        if (!LoadSave(bf))
        {
            Debug.Log("No saved data found");
        }
        else
        {
            WorldObjectSave worldObjectSave = GameObject.FindGameObjectWithTag("LevelSave").GetComponent<WorldObjectSave>();
            worldObjectSave.LoadLevelList(m_Save);
        }
        
        
    }

    private static bool LoadSave(BinaryFormatter bf)
    {
        if (!File.Exists(m_FilePath))
        {
            Debug.Log(m_FilePath);
            return false;
        }

        using (FileStream stream = new FileStream(m_FilePath, FileMode.Open, FileAccess.Read))
        {
            m_Save = bf.Deserialize(stream) as WorldSave;
        }

        return true;
    }
    // public void Serialize(WorldLevelGO _save)
    //{
    //    if(_save != null)
    //    {

    //        BinaryFormatter bf = new BinaryFormatter();
    //        FileStream stream = new FileStream(FILE_PATH, FileMode.Create);
    //        bf.Serialize(stream, m_Save);
    //        stream.Close();

    //    }

    //}

    //public void Deserialize()
    //{
    //    if(File.)
    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream stream = new FileStream(FILE_PATH, FileMode.Open);
    //    m_Save = bf.Deserialize(stream) as WorldLevelGO;
    //    stream.Close();
    //    Debug.Log("Level deserialized");
    //}
}
