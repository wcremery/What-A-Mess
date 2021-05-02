using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public void Save()
    {
        string jsonString = JsonConvert.SerializeObject(this);
        Debug.Log("Saving json..." + jsonString);
    }
    
    public void Load()
    {
        Debug.Log("Loading json...");
    }
}
