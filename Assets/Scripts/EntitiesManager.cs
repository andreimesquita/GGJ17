using UnityEngine;

public class EntitiesManager : MonoBehaviour
{
    public SpaceshipBehaviour spaceshipLeft;
    public SpaceshipBehaviour spaceshipRight;

    public void RespawnPlayers()
    {
        spaceshipLeft.transform.position = Vector3.right * 1f;
        spaceshipRight.transform.position = Vector3.right * -1f;

        spaceshipLeft.gameObject.SetActive(true);
        spaceshipRight.gameObject.SetActive(true);
    }
}