using UnityEngine;

namespace Assets.Scripts.So
{
    [CreateAssetMenu(fileName = "AudioListSo", menuName = "Scriptable Object")]
    public class AudioListSo : ScriptableObject
    {
        public AudioClip AsteroidFallClip;
        public AudioClip ClickClip;

        public AudioClip SoundTrack;
        public AudioClip SpaceshipClip;
    }
}