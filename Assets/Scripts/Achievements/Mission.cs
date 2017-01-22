using System;
using System.Collections.Generic;
using UnityEngine;

namespace Achievements
{
    [Serializable]
    public class SwKeyValuePair
    {
        public MissionType Key;
        public float Value;

        public SwKeyValuePair() { }

        public SwKeyValuePair(MissionType key, float value)
        {
            Key = key;
            Value = value;
        }
    }

    [CreateAssetMenu(fileName = "newMission", menuName = "Mission")]
    public class Mission : ScriptableObject
    {
        public bool IsSucceded;

        public List<SwKeyValuePair> Values;

        public string PresentationText;

        public override string ToString()
        {
            return PresentationText;
        }
    }
}