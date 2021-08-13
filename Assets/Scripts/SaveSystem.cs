using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
    public static void SavePlayerAndScore(int bestScore, string name)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string path = Application.persistentDataPath + "/player.txt";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(bestScore, name);

        formatter.Serialize(stream, data);

        stream.Close();

    }
    
    public static PlayerData LoadPlayerAndScore()
    {
        string path = Application.persistentDataPath + "/player.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            try
            {
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                return data;
            }
            catch
            {
                Debug.LogErrorFormat("Failed to load file at {0}", path);
                stream.Close();
                return null;
            }
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
