using UnityEngine;

namespace Settings
{
    [System.Serializable]
    public class SerializableRotation
    {
        [SerializeField] private float rotationX;
        [SerializeField] private float rotationY;
        [SerializeField] private float rotationZ;
        [SerializeField] private float rotationW;

        public SerializableRotation(float rotationX, float rotationY, float rotationZ, float rotationW)
        {
            this.rotationX = rotationX;
            this.rotationY = rotationY;
            this.rotationZ = rotationZ;
            this.rotationW = rotationW;
        }

        public Quaternion GetQuaternion()
        {
            return new Quaternion(this.rotationX, this.rotationY, this.rotationZ, this.rotationW);
        }
    }
}
