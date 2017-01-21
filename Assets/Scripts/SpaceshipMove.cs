using UnityEngine;

public class SpaceshipMove : MonoBehaviour
{
    [SerializeField]
    private float currentVelocity;

    [SerializeField]
    private float defaultXVelocity = 10.0f;

    private Vector3 currentPosition;

    private float currentRotation;

    private float currentRotationVelocity = 0.0f;

    [SerializeField]
    private float rotationVelocity = 200.0f;

    [SerializeField]
    private KeyCode toggleButton;

    private void Start()
    {
        currentPosition = transform.position;
        currentVelocity = defaultXVelocity;
        currentRotation = 0.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleButton))
        {
            TogglePosition();
        }

        this.transform.position = Vector3.Slerp(this.transform.position, currentPosition, Time.deltaTime * 200.0f);

        currentRotation += Time.deltaTime * currentRotationVelocity * rotationVelocity;

        currentRotation = Mathf.Clamp(currentRotation, -45.0f, 45.0f);

        this.transform.localRotation = Quaternion.Euler(Vector3.forward * currentRotation);
    }

    private void FixedUpdate()
    {
        currentPosition.x = Mathf.Lerp(currentPosition.x, Mathf.Clamp(currentPosition.x + currentVelocity * Time.fixedDeltaTime, -2.5f, 2.5f), Time.fixedDeltaTime * 20.0f);
    }

    public void TogglePosition()
    {
        currentVelocity = -currentVelocity;
        currentRotationVelocity = -Mathf.Clamp(currentVelocity, -1, 1);
    }
}
