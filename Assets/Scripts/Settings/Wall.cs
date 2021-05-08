using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [System.Serializable]
    public class Wall
    {
        [SerializeField] private SerializablePosition wallPosition;
        [SerializeField] private SerializableRotation wallRotation;
        [SerializeField] private SerializableScale wallScale;
        [SerializeField] private bool isColliding;

        public Wall()
        {
            wallPosition = new SerializablePosition(0, 0, 0);
            wallRotation = new SerializableRotation(0, 0, 0, 1);
            wallScale = new SerializableScale(0, 0, 0);

            isColliding = true;
        }

        public SerializablePosition WallPosition => wallPosition;

        public SerializableRotation WallRotation => wallRotation;

        public SerializableScale WallScale => wallScale;

        public bool IsColliding => isColliding;
    }
}