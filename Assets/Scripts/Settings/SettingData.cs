using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{ 
    [System.Serializable]
    public class SettingData
    {
        [SerializeField] private Wall[] walls;

        public SettingData()
        {
            this.walls = new Wall[4];
        }
    }
    
    
    
}