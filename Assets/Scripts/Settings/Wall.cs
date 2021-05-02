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
            wallRotation = new SerializableRotation(0, 0, 0, 0);
            wallScale = new SerializableScale(0, 0, 0);

            isColliding = true;
        }

        public void Setup(GameObject gameObject)
        {
            Transform transformGO = gameObject.transform;
            Vector3 position = transformGO.position;
            Quaternion rotation = transformGO.rotation;
            Vector3 scale = transformGO.localScale;

            wallPosition = new SerializablePosition(position.x, position.y, position.z);
            wallRotation = new SerializableRotation(rotation.x, rotation.y, rotation.z, rotation.w);
            wallScale = new SerializableScale(scale.x, scale.y, scale.z);

            isColliding = true;
        }
    }
}