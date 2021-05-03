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
        [SerializeField] private Player player;
        
        public SettingData()
        {
            this.walls = new Wall[4];
            this.player = new Player();
        }

        public Wall[] Walls => walls;

        public Player Player => player;
    }
    
    
    
}