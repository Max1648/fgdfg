using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LocalDataManager
{
    //public PlayerData PlayerData1;
    public static string BasePath = "saveData.json";

    public static string PlayerPath = "savePlayerData.json";

    public static void Save<T>(T data)
    {
        string filePath = Path.Combine(Application.persistentDataPath, BasePath);
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, jsonData);
    }

      public static void SavePlayerData<T>(T data)
    {
        string filePath = Path.Combine(Application.persistentDataPath, PlayerPath);
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, jsonData);
    }

    public static T Load<T>()
    {
        string filePath = Path.Combine(Application.persistentDataPath, BasePath);
        string jsonData = File.ReadAllText(filePath);
       // T data;
       // if (!isScriptable)
        var data = JsonUtility.FromJson<T>(jsonData);
      //  else
         //    data = JsonUtility.FromJsonOverwrite<T>(jsonData);
        return data;
    }

    public static void LoadScritableObject(PlayerData playerData)
    {
        string filePath = Path.Combine(Application.persistentDataPath, BasePath);
        if (File.Exists(filePath))
        {        
        string jsonData = File.ReadAllText(filePath);
      //  PlayerData1 = playerData;
        JsonUtility.FromJsonOverwrite(jsonData,playerData);
        } else
        {
            Debug.Log("?????????????????????/////");
        }
    }
}