using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [System.Serializable]
    public class Player
    {
        [SerializeField] private SerializablePosition startPosition;
        [SerializeField] private Image image;
        [SerializeField] private string shape;
        [SerializeField] private float radius;

        public Player()
        {
            startPosition = new SerializablePosition(0, 0, 0);
            image = new Image();
            shape = "circle";
            radius = 0.7f;
        }

        public SerializablePosition StartPosition => startPosition;

        public Image Image => image;

        public string Shape => shape;

        public float Radius => radius;
    }
}