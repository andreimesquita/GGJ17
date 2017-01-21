using UnityEngine;

public class MobileInputController : MonoBehaviour
{
    public void OnRightScreenPressed()
    {
        GameManager.Instance.entities.spaceshipRight.ToggleDirection();
    }

    public void OnLeftScreenPressed()
    {
        GameManager.Instance.entities.spaceshipLeft.ToggleDirection();
    }
}