using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [System.Serializable]
    public class Wall : MonoBehaviour
    {
        [SerializeField] private SerializablePosition wallPosition;
        [SerializeField] private SerializableRotation wallRotation;
        [SerializeField] private SerializableScale wallScale;

        private void Awake()
        {
            Transform transformGO = gameObject.transform;
            Vector3 position = transformGO.position;
            Quaternion rotation = transformGO.rotation;
            
            wallPosition = new SerializablePosition(position.x, position.y, position.z);
            wallRotation = new SerializableRotation(rotation.x, rotation.y, rotation.z, rotation.w);
        }
    }
}