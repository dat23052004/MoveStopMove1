using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


// You can only save numbers, booleans, strings, chars and array of these types
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance {  get; private set; }

    // What we want to save
    public int CurrentWeapon;

    private void Awake()
    {
        if(instance != null  && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
        Load();
    }


    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "playerInfor.data"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "playerInfor.data", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            CurrentWeapon = data.currentWeapon;
            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "playerInfor.data");
        PlayerData_Storage data = new PlayerData_Storage();

        data.currentWeapon = CurrentWeapon;

        bf.Serialize(file, data);
        file.Close();
    }
}

[SerializeField]
class PlayerData_Storage
{
    public int currentWeapon;

}
