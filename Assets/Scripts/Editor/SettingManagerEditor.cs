using System;
using System.Collections;
using System.Collections.Generic;
using Settings;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SettingManager))]
public class SettingManagerEditor : Editor
{
    private SettingManager settingManager;

    private void OnEnable()
    {
        settingManager = (SettingManager) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Save"))
        {
            settingManager.Save();
        }

        else if (GUILayout.Button("Load"))
        {
            settingManager.Load();
        }
    }
}
