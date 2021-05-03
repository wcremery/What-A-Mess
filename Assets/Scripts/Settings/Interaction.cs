using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [System.Serializable]
    public class Interaction
    {
        [SerializeField] private string firstActor;
        [SerializeField] private string secondActor;
        [SerializeField] private string message;

        public Interaction()
        {
            message = "";
        }

        public string FirstActor => firstActor;

        public string SecondActor => secondActor;

        public string Message => message;
    }
}