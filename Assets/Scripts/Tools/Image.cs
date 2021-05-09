using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Image
{
    [SerializeField] private string spriteName;
    [SerializeField] private int orderInLayer;

    public Image()
    {
        spriteName = "zombie";
        orderInLayer = 1;
    }

    public string SpriteName => spriteName;

    public int OrderInLayer => orderInLayer;
}
