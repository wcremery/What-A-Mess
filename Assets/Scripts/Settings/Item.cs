using UnityEngine;

namespace Settings
{
    [System.Serializable]
    public class Item
    {
        [SerializeField] private SerializablePosition itemPosition;
        [SerializeField] private SerializableRotation itemRotation;
        [SerializeField] private SerializableScale itemScale;
        [SerializeField] private bool isColliding;
        [SerializeField] private bool isDisplayed;
        [SerializeField] private string[] spriteName; // path for all sprites and states associated
        [SerializeField] private string tag;

        public Item()
        {
            itemPosition = new SerializablePosition(0, 0, 0);
            itemRotation = new SerializableRotation(0, 0, 0, 1);
            itemScale = new SerializableScale(0, 0, 0);
            isColliding = true;
            isDisplayed = true;
            spriteName = new string[1];
            tag = "Untagged";
        }
    }
}
