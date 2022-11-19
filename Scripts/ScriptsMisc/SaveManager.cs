using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static void SavePlayerData(FPS_Player player)
    {
        Save save = new Save(player);
        string dataPath = Application.persistentDataPath + "/player.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, save);
        fileStream.Close();
    }
    public static void SavePoints(GameManager gameManager)
    {
        Save save = new Save(gameManager);
        string dataPath1 = Application.persistentDataPath + "/points.save";
        FileStream fileStream = new FileStream(dataPath1, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, save);
        fileStream.Close();
    }

    public static Save LoadSave()
    {
        string dathaPath = Application.persistentDataPath + "/player.save";
        if (File.Exists(dathaPath))
        {
            FileStream fileStream = new FileStream(dathaPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Save save = (Save)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return save;
        }
        else
        {
            Debug.LogError("sin archivo");
            return null;
        }
    }
    public static Save LoadPoints()
    {
        string playerPointsPath = Application.persistentDataPath + "/points.save";
        if (File.Exists(playerPointsPath))
        {
            FileStream fileStream = new FileStream(playerPointsPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Save save = (Save)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return save;
        }
        else
        {
            Debug.LogError("sin puntos");
            return null;
        }
    }
}
