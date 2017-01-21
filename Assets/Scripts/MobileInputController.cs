using UnityEngine;

public class MobileInputController : MonoBehaviour
{
    public void OnRightScreenPressed()
    {
        GameManager.Instance.entities.spaceshipRight.TogglePosition();
    }

    public void OnLeftScreenPressed()
    {
        GameManager.Instance.entities.spaceshipLeft.TogglePosition();
    }
}