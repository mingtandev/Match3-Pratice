
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public static class SaveLoadManager
{
    
    public static void SaveData(DataPlayer data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/leveldata.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataPlayer myData = new DataPlayer(data);

        formatter.Serialize(stream, myData);
        stream.Close();
    }

    public static DataPlayer LoadData()
    {
        string path = Application.persistentDataPath + "/leveldata.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataPlayer data = formatter.Deserialize(stream) as DataPlayer;

            return data;


        }
        else
        {
            Debug.LogError("File not exist");
            return null;
        }
    }
}
