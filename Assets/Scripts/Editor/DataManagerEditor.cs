using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DataManager))]
public class DataManagerEditor : Editor
{
    private string _jsonSaveFilePath;

    private DataManager _dataManager;
    private string applicationPath;
    private string jsonFileName;

    private void OnEnable()
    {
        applicationPath = Application.dataPath;
        _jsonSaveFilePath = applicationPath + "/Data/GameData3.json";
        _dataManager = (DataManager) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        
        GUILayout.Label("Load path");
        jsonFileName = "GameData";
        jsonFileName = GUILayout.TextField(jsonFileName);

        if (GUILayout.Button("Load"))
        {
            _dataManager.Load(applicationPath + "/Data/" + jsonFileName + ".json");
        }
        
        else if (GUILayout.Button("Setup"))
        {
            _dataManager.Setup();
        }

        else if (GUILayout.Button("Save"))
        {
            _dataManager.Save(_jsonSaveFilePath);
        }
        
        else if (GUILayout.Button("Reset"))
        {
            _dataManager.Reset();
        }
    }
}