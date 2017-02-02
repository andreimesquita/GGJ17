using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    public class EntitiesManager : MonoBehaviour
    {
        public SpaceshipBehaviour spaceshipLeft;
        public SpaceshipBehaviour spaceshipRight;
        public Text scoreText;

        public void RespawnPlayers()
        {
            spaceshipLeft.transform.position = Vector3.right * 1f;
            spaceshipRight.transform.position = Vector3.right * -1f;

            spaceshipLeft.gameObject.SetActive(true);
            spaceshipRight.gameObject.SetActive(true);
        }

    }
}