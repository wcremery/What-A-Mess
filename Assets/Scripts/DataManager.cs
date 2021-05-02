using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Settings;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private SettingData _settingData;

    private Dictionary<string, SettingData> _setting;
    
    private Wall[] _walls;
    private GameObject[] _wallGO;

    public void Load(string jsonFilePath)
    {
        Debug.Log("Loading json...");
        
        if (!File.Exists(jsonFilePath))
        {
            Debug.LogError("[FAILURE] while loading json");
            return;
        }

        string jsonContent = File.ReadAllText(jsonFilePath);

        ParseJson(jsonContent);
    }

    private void ParseJson(string jsonContent)
    {
        _setting = JsonConvert.DeserializeObject<Dictionary<string, SettingData>>(jsonContent);
    }

    public void Save(string jsonFilePath)
    {
        Debug.Log("Saving json...");
        string jsonContent = JsonUtility.ToJson(_settingData);
        File.WriteAllText(jsonFilePath, jsonContent);
    }

    public void GetRefs()
    {
        GetWallRefs();
        _settingData = new SettingData();
    }

    private void GetWallRefs()
    {
        _wallGO = GameObject.FindGameObjectsWithTag("wall");
    }
}