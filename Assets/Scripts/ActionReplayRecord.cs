using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class ActionReplayRecord
    {
        public Vector3 position;
        public Quaternion rotation;
        public string timestamp;
        public bool isActive;
        public string tag;
        public string name;
        public int layer;

        public string Stringify() 
        {
            return JsonUtility.ToJson(this);
        }

    }
}