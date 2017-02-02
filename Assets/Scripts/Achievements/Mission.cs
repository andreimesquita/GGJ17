using System;
using System.Collections.Generic;
using SmartLocalization;
using UnityEngine;

namespace Assets.Scripts.Achievements
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

        public string PresentationTextKey;

        public List<SwKeyValuePair> Values;

        public override string ToString()
        {
            return LanguageManager.Instance.GetTextValue(PresentationTextKey);
        }
    }
}