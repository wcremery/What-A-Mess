using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Settings;
using UnityEngine;
using UnityEngine.Serialization;

public class DataManager : MonoBehaviour
{
    [Header("Scene Customization")]
    [SerializeField] private SettingData _setting;
    
    private readonly string dynamicNameGO = "==DYNAMIC==";

    public SettingData Setting => _setting;

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
    }

    private void ParseJson(string jsonContent)
    {
        _setting = JsonUtility.FromJson<SettingData>(jsonContent);
    }

    public void Save(string jsonFilePath)
    {
        Debug.Log("Saving json...");
        
        string jsonContent = JsonUtility.ToJson(_setting);
        File.WriteAllText(jsonFilePath, jsonContent);
    }

    public void Setup()
    {
        SetupWalls();
        SetupItems();
        SetupPlayer();

    }

    private void SetupItems()
    {
        Item[] items = _setting.Items;
        GameObject itemsParent = new GameObject("Items");
        itemsParent.transform.parent = GameObject.Find(dynamicNameGO).transform;

        for (int i = 0; i < items.Length; i++)
        {
            Item currentItem = items[i];
            GameObject go = new GameObject(currentItem.Tag);
            go.transform.parent = itemsParent.transform;
            go.tag = currentItem.Tag;
            go.transform.position = currentItem.ItemPosition.GetVector3();
            go.transform.rotation = currentItem.ItemRotation.GetQuaternion();
            go.transform.localScale = currentItem.ItemScale.GetVector3();
            go.AddComponent<SpriteRenderer>();
            go.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(currentItem.SpriteName);
            go.GetComponent<SpriteRenderer>().sortingOrder = 1;
            go.GetComponent<SpriteRenderer>().enabled = currentItem.IsDisplayed;
            go.AddComponent<CircleCollider2D>();
            go.GetComponent<CircleCollider2D>().isTrigger = !currentItem.IsColliding;
        }
        
    }

    private void SetupPlayer()
    {
        Player player = _setting.Player;
        GameObject playerParent = GameObject.Find(dynamicNameGO);

        GameObject go = new GameObject("Player");
        go.transform.parent = playerParent.transform;
        go.transform.position = player.StartPosition.GetVector3();
        go.transform.localScale *= 1.5f;
        go.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(player.Image.SpriteName);
        go.GetComponent<SpriteRenderer>().sortingOrder = player.Image.OrderInLayer;
        if (player.Shape.Equals("circle"))
        {
            go.AddComponent<CircleCollider2D>();
            go.GetComponent<CircleCollider2D>().radius = player.Radius;
        }

        go.AddComponent<PlayerController>();
    }

    private void SetupWalls()
    {
        Wall[] walls = _setting.Walls;
        GameObject wallsParent = new GameObject("Walls");
        wallsParent.transform.parent = GameObject.Find(dynamicNameGO).transform;

        for (int i = 0; i < walls.Length; i++)
        {
            GameObject go = new GameObject("Wall");
            go.transform.parent = wallsParent.transform;
            go.tag = "Wall";
            go.transform.position = walls[i].WallPosition.GetVector3();
            go.transform.rotation = walls[i].WallRotation.GetQuaternion();
            go.transform.localScale = walls[i].WallScale.GetVector3();
            go.AddComponent<SpriteRenderer>();
            go.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Wall");
            if (walls[i].IsColliding)
            {
                go.AddComponent<BoxCollider2D>();
            }
        }
    }

    public void Reset()
    {
        while (GameObject.Find(dynamicNameGO).transform.childCount > 0) 
        {
            DestroyImmediate(GameObject.Find(dynamicNameGO).transform.GetChild(0).gameObject);
        }
    }
}