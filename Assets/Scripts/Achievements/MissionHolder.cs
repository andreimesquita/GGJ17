using UnityEngine;
using UnityEngine.UI;

namespace Achievements
{
    public class MissionHolder : MonoBehaviour
    {
        public const int SILVER_MEDAL_CHILD_ID = 0;
        public const int GOLD_MEDAL_CHILD_ID = 1;

        public Text presentationText;
        public Transform medalsParent;
        public Image backgroundImage;

        public Color completedColor;

        public void SetCompleted()
        {
            backgroundImage.color = completedColor;
        }
    }
}
