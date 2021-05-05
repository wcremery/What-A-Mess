using UnityEngine;


[System.Serializable]
public class SerializablePosition
{
    [SerializeField] private float positionX;
    [SerializeField] private float positionY;
    [SerializeField] private float positionZ;

    public SerializablePosition(float positionX, float positionY, float positionZ)
    {
        this.positionX = positionX;
        this.positionY = positionY;
        this.positionZ = positionZ;
    }

    public Vector3 GetVector3()
    {
        return new Vector3(this.positionX, this.positionY, this.positionZ);
    }
}