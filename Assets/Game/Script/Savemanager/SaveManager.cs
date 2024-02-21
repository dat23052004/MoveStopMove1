using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


// You can only save numbers, booleans, strings, chars and array of these types
public class SaveManager : Singleton<SaveManager>
{
    public void SaveData<T>(T data)
    {
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/" + typeof(T).ToString() + ".json", json);
    }

    public T LoadData<T>()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/" + typeof(T).ToString() + ".json");
        return JsonUtility.FromJson<T>(json);
    }

    public void DeleteData<T>()
    {
        File.Delete(Application.persistentDataPath + "/" + typeof(T).ToString() + ".json");
    }

    public bool HasData<T>()
    {
        return File.Exists(Application.persistentDataPath + "/" + typeof(T).ToString() + ".json");
    }
}
