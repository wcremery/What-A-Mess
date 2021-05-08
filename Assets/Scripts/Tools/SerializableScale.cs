using UnityEngine;


[System.Serializable]
public class SerializableScale
{
    [SerializeField] private float scaleX;
    [SerializeField] private float scaleY;
    [SerializeField] private float scaleZ;

    public SerializableScale(float scaleX, float scaleY, float scaleZ)
    {
        this.scaleX = scaleX;
        this.scaleY = scaleY;
        this.scaleZ = scaleZ;
    }

    public Vector3 GetVector3()
    {
        return new Vector3(this.scaleX, this.scaleY, this.scaleZ);
    }
}