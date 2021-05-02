using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DataManager))]
public class DataManagerEditor : Editor
{
    private string _jsonSaveFilePath;
    
    private DataManager _dataManager;

    private void OnEnable()
    {
        _jsonSaveFilePath = Application.dataPath + "/Data/GameData.json";
        _dataManager = (DataManager) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        string jsonLoadPath = "";
        GUILayout.Label("Load path");
        jsonLoadPath = GUILayout.TextField(jsonLoadPath);

        if (GUILayout.Button("Load"))
        {
            _dataManager.Load(jsonLoadPath);
        }

        else if (GUILayout.Button("Save"))
        {
            _dataManager.Save(_jsonSaveFilePath);
        }

        else if (GUILayout.Button("Get Refs"))
        {
            _dataManager.GetRefs();
        }
    }
}