using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static ConfigData _configData;

    private void Awake()
    {
        LoadData();
    }

    public static void LoadData()
    {
        var saveFile = Application.persistentDataPath + "/config.data";
        Debug.Log(saveFile);
        if(File.Exists(saveFile))
        {
            _configData = JsonUtility.FromJson<ConfigData>(File.ReadAllText(saveFile));
        }
        else
        {
            var configData = new ConfigData();
            var jsonString = JsonUtility.ToJson(configData);
            File.WriteAllText(saveFile, jsonString);
        }
    }

    public static void SaveData(ConfigData configData)
    {
        var saveFile = Application.persistentDataPath + "/config.data";
        var jsonString = JsonUtility.ToJson(configData);
        File.WriteAllText(saveFile, jsonString);
    }

    public static ConfigData GetConfigData()
    {
        return _configData;
    }
}
