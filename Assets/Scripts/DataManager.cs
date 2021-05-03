using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Settings;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private SettingData _settingData;

    private SettingData _setting;

    private string dynamicNameGO = "==DYNAMIC==";
    private Wall[] _walls;
    private Player _player;

    public void Load(string jsonFilePath)
    {
        Debug.Log("Loading json...");

        if (!File.Exists(jsonFilePath))
        {
            Debug.LogError("[FAILURE] while loading json. The json file might not exist in the Data folder :(");
            return;
        }

        string jsonContent = File.ReadAllText(jsonFilePath);

        ParseJson(jsonContent);

        Debug.Log(_setting.Walls[0].IsColliding);
    }

    private void ParseJson(string jsonContent)
    {
        _setting = JsonUtility.FromJson<SettingData>(jsonContent);
    }

    public void Save(string jsonFilePath)
    {
        Debug.Log("Saving json...");

        _settingData = new SettingData();
        string jsonContent = JsonUtility.ToJson(_settingData);
        File.WriteAllText(jsonFilePath, jsonContent);
    }

    public void Setup()
    {
        GameObject dynamic = new GameObject(dynamicNameGO);
        SetupWalls();
        SetupPlayer();
    }

    private void SetupPlayer()
    {
        _player = new Player();
        GameObject playerParent = GameObject.Find(dynamicNameGO);

        GameObject go = new GameObject("Player");
        go.transform.parent = playerParent.transform;
        go.transform.position = _player.StartPosition.GetVector3();
        go.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(_player.Image.SpriteName);
        go.GetComponent<SpriteRenderer>().sortingOrder = _player.Image.OrderInLayer;
        if (_player.Shape.Equals("circle"))
        {
            go.AddComponent<CircleCollider2D>();
        }

        go.AddComponent<PlayerController>();
        SetupPlayerCamera(go);
    }

    private void SetupPlayerCamera(GameObject go)
    {
        GameObject camera = new GameObject("Main Camera");
        camera.transform.parent = go.transform;
        camera.transform.position = new Vector3(0, 0, -10);
        camera.AddComponent<Camera>();
        camera.GetComponent<Camera>().backgroundColor = Color.black;
    }

    private void SetupWalls()
    {
        Wall[] walls = _setting.Walls;
        GameObject wallsParent = new GameObject("Walls");
        wallsParent.transform.parent = GameObject.Find(dynamicNameGO).transform;

        for (int i = 0; i < walls.Length; i++)
        {
            GameObject go = new GameObject("wall");
            go.transform.parent = wallsParent.transform;
            go.transform.position = walls[i].WallPosition.GetVector3();
            go.transform.rotation = walls[i].WallRotation.GetQuaternion();
            go.transform.localScale = walls[i].WallScale.GetVector3();
            if (walls[i].IsColliding)
            {
                go.AddComponent<BoxCollider2D>();
            }
        }
    }

    public void Reset()
    {
        Transform[] allChildren = GameObject.Find(dynamicNameGO).GetComponentsInChildren<Transform>();
        
        for (int i = 0; i < allChildren.Length; i++)
        {
            DestroyImmediate(allChildren[i].gameObject);
        }
    }
}