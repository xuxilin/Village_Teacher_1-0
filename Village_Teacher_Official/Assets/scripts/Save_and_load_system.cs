using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class Save_and_load_system : MonoBehaviour
{
    // Start is called before the first frame update
    public static Save_and_load_system instance;
    public SaveData SaveD;
    public bool has_load;
    private void Awake()
    {
        instance = this;
        //Load();

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S hited");
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("L hited");
            Load();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C hited");
            Delete();
        }*/
    }
    public void Save()
    {
        string Data_path = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(Data_path + "/" + SaveD.name_of_save + ".txt", FileMode.Create);
        serializer.Serialize(stream, SaveD);
        stream.Close();

        Debug.Log("Saved");
    }
    public void Load()
    {
        string Data_path = Application.persistentDataPath;
        if (System.IO.File.Exists(Data_path + "/" + SaveD.name_of_save + ".txt"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(Data_path + "/" + SaveD.name_of_save + ".txt", FileMode.Open);
            SaveD = serializer.Deserialize(stream) as SaveData;
            stream.Close();

            Debug.Log("Loaded");
            has_load = true;
        }

    }
    public void Delete()
    {
        string Data_path = Application.persistentDataPath;
        if (System.IO.File.Exists(Data_path + "/" + SaveD.name_of_save + ".txt"))
        {
            File.Delete(Data_path + "/" + SaveD.name_of_save + ".txt");
        }
    }
}

[System.Serializable]
public class SaveData {
        public string name_of_save = "Save1";

        public Vector3 player_location;

        public int scene_num;

        public bool loaded = false;
    }
    