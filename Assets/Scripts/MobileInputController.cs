using UnityEngine;

public class MobileInputController : MonoBehaviour
{
    [SerializeField] private float inputTimeDelay;
    [SerializeField] private float inputLockDelay;
    [SerializeField] private Timer timer;

    private bool waitingLeftPressExecution;
    private bool waitingRightPressExecution;

    private void Awake()
    {
        this.inputTimeDelay = 0.16f;
        this.inputLockDelay = 0.6f;
    }

    private void ToggleWaitingRightPressExecution()
    {
        this.waitingRightPressExecution = !this.waitingRightPressExecution;
    }

    private void ToggleWaitingLeftPressExecution()
    {
        this.waitingLeftPressExecution = !this.waitingLeftPressExecution;
    }

    public void OnRightScreenPressed()
    {
        if (waitingRightPressExecution) return;

        ToggleWaitingRightPressExecution();

        timer.RegisterCallback(inputTimeDelay, GameManager.Instance.entities.spaceshipRight.ToggleDirection);
        timer.RegisterCallback(inputLockDelay, ToggleWaitingRightPressExecution);
    }

    public void OnLeftScreenPressed()
    {
        if (waitingLeftPressExecution) return;

        ToggleWaitingLeftPressExecution();

        timer.RegisterCallback(inputTimeDelay, GameManager.Instance.entities.spaceshipLeft.ToggleDirection);
        timer.RegisterCallback(inputLockDelay, ToggleWaitingLeftPressExecution);
    }


}