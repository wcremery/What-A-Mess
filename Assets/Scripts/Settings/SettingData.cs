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
        [SerializeField] private Interaction[] interactions;
        [SerializeField] private Item[] items;
        
        public SettingData()
        {
            this.walls = new Wall[4];
            this.player = new Player();
            this.interactions = new Interaction[1];
            this.items = new Item[1];
        }

        public Wall[] Walls => walls;

        public Player Player => player;

        public Interaction[] Interactions => interactions;

        public Item[] Items => items;
    }
    
    
    
}