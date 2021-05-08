using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 playerPosition;
    private Vector3 offset;
    
    private void Start()
    {
        playerPosition = GameObject.Find("==DYNAMIC==/Player").transform.position;
        offset = transform.position - playerPosition;
    }

    // LateUpdate is called after Update each frame
    private void LateUpdate()
    {
        playerPosition = GameObject.Find("==DYNAMIC==/Player").transform.position;
        transform.position = playerPosition + offset;
    }
}
