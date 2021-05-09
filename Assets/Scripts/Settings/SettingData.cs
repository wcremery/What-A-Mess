using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{ 
    [System.Serializable]
    public class SettingData
    {
        [SerializeField] private Player player;
        [SerializeField] private Interaction[] interactions;
        [SerializeField] private Item[] items;
        [SerializeField] private Wall[] walls;
        
        public SettingData()
        {
            this.player = new Player();
            this.interactions = new Interaction[1];
            this.items = new Item[1];
            this.walls = new Wall[4];
        }

        public Player Player => player;

        public Interaction[] Interactions => interactions;

        public Item[] Items => items;
        
        public Wall[] Walls => walls;
    }
}