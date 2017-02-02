using UnityEngine;

namespace Assets.Scripts.So
{
    [CreateAssetMenu(fileName = "SpaceshipsListSo", menuName = "Scriptable Object")]
    public class SpaceshipsListSo : ScriptableObject
    {
        public Sprite[] spaceshipsSprites;
    }
}