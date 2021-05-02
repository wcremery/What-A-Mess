using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DataManager))]
public class DataManagerEditor : Editor
{
    private DataManager dataManager;

    private void OnEnable()
    {
        dataManager = (DataManager) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Save"))
        {
            dataManager.Save();
        }

        else if (GUILayout.Button("Load"))
        {
            dataManager.Load();
        }
    }
}
