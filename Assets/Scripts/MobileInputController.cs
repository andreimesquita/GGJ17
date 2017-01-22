using UnityEngine;

public class MobileInputController : MonoBehaviour
{
    private bool holdingDownLeft;
    private bool holdingDownRight;

    public void OnRightScreenUp()
    {
        this.holdingDownRight = false;

        GameManager.Instance.entities.spaceshipRight.spaceshipMove.ToggleDirection();
    }

    public void OnLeftScreenUp()
    {
        this.holdingDownLeft = false;

        GameManager.Instance.entities.spaceshipLeft.spaceshipMove.ToggleDirection();
    }

    public void OnRightScreenDown()
    {
        if (holdingDownRight) return;

        this.holdingDownRight = true;

        GameManager.Instance.entities.spaceshipRight.spaceshipMove.ToggleDirection();
    }

    public void OnLeftScreenDown()
    {
        if (holdingDownLeft) return;

        this.holdingDownLeft = true;

        GameManager.Instance.entities.spaceshipLeft.spaceshipMove.ToggleDirection();
    }
}