//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using So;
//using UnityEngine;
//using Object = System.Object;

//namespace Util
//{
//    public static class Utils
//    {
//        public static AudioClip LoadRandomAudioClip(this AudioListSo audioListSo, string audioClipNameWithoutRandomNumber, int min, int max)
//        {
//            int randomClip = Random.Range(min, max);
//            string audioClipName = string.Format(string.Concat(audioClipNameWithoutRandomNumber, "{0}"), randomClip);

//            return LoadAudioClip(audioListSo, audioClipName);
//        }

//        public static AudioClip LoadAudioClip(this AudioListSo audioListSo, string audioClipName)
//        {
//            AudioClip audioclip = audioListSo.audioClips.FirstOrDefault(ac => ac.name == audioClipName);
//            return audioclip;
//        }
//    }
//}
