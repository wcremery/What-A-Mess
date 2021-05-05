using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DataManager))]
public class DataManagerEditor : Editor
{
    private readonly string _dataFolder = "/Data/";
    private readonly string _jsonExtension = ".json";
    
   
    private DataManager _dataManager;
    private string _applicationPath;
    private string _jsonFileName;
    private string _jsonSaveFilePath;

    private void OnEnable()
    {
        _applicationPath = Application.dataPath;
        _dataManager = (DataManager) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        GUILayout.Label("Load data", EditorStyles.boldLabel);
        
        GUILayout.Label("File name");
        _jsonFileName = GUILayout.TextField(_jsonFileName);
        
        if (GUILayout.Button("Load"))
        {
            _dataManager.Load(_applicationPath + _dataFolder + _jsonFileName + _jsonExtension);
        }
        
        GUILayout.Label("Save data", EditorStyles.boldLabel);
        
        GUILayout.Label("File name");
        _jsonSaveFilePath = GUILayout.TextField(_jsonSaveFilePath);
        
        if (GUILayout.Button("Save"))
        {
            _dataManager.Save(_applicationPath + _dataFolder + _jsonSaveFilePath + _jsonExtension);
        }

        GUILayout.Label("Apply", EditorStyles.boldLabel);

        if (GUILayout.Button("Setup"))
        {
            _dataManager.Setup();
        }

        else if (GUILayout.Button("Reset"))
        {
            _dataManager.Reset();
        }
    }
}