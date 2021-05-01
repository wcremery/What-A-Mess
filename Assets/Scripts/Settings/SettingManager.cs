using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{ 
    [System.Serializable]
    public class SettingManager : MonoBehaviour
    {
        [SerializeField] private Wall[] wallArray;

        public void Save()
        {
            Debug.Log("Saving json...");
        }

        public void Load()
        {
            Debug.Log("Loading json...");
        }
    }
}