using UnityEngine;

namespace So
{
    [CreateAssetMenu(fileName = "AudioListSo", menuName = "Scriptable Object")]
    public class AudioListSo : ScriptableObject
    {
        public AudioClip AsteroidFallClip;
    }
}