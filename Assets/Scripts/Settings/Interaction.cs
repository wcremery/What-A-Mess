using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [System.Serializable]
    public struct Interaction
    {
        [SerializeField] private string firstActor;
        [SerializeField] private string secondActor;
        [SerializeField] private string[] message;
        [SerializeField] private string[] sprites;

        public string FirstActor => firstActor;

        public string SecondActor => secondActor;

        public string[] Message => message;

        public string[] Sprites => sprites;
    }
}