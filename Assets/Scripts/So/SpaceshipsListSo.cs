using UnityEngine;

namespace So
{
    [CreateAssetMenu(fileName = "SpaceshipsListSo", menuName = "Scriptable Object")]
    public class SpaceshipsListSo : ScriptableObject
    {
        public Sprite[] spaceshipsSprites;
    }
}