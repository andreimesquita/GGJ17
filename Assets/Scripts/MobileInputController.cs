using UnityEngine;

public class MobileInputController : MonoBehaviour
{
    [SerializeField] private float inputTimeDelay;
    [SerializeField] private Timer timer;

    private void Awake()
    {
        this.inputTimeDelay = 0.15f;
    }

    public void OnRightScreenPressed()
    {
        timer.RegisterCallback(inputTimeDelay, GameManager.Instance.entities.spaceshipRight.ToggleDirection);
    }

    public void OnLeftScreenPressed()
    {
        timer.RegisterCallback(inputTimeDelay, GameManager.Instance.entities.spaceshipLeft.ToggleDirection);
    }
}