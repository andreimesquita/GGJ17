using UnityEditor;
using UnityEngine;

public class SpaceshipMove : MonoBehaviour
{
    [SerializeField] private AnimationCurve accelerationCurve;
    [SerializeField] private float maximumVelocity;
    [SerializeField] private float minimumVelocity;
    [SerializeField] private float accelerationRate;
    [SerializeField] private float steeringDumping;
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private float direction;
    [SerializeField] private LineRenderer lineRenderer;

    private float maximumSteeringAngle;
    

    private Vector2 directionVector;
    private Quaternion maximumSteeringQuaternion;
    private float currentVelocity;

    private void Awake()
    {
        this.maximumVelocity = 6.0f;
        this.minimumVelocity = 1.0f;
        this.accelerationRate = 8.0f;
        this.maximumSteeringAngle = 60.0f;
        this.steeringDumping = 0.25f;

        this.directionVector = new Vector2(direction, 0.0f);
        this.maximumSteeringQuaternion = Quaternion.AngleAxis(maximumSteeringAngle, Vector3.forward);
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            ToggleDirection();
        }
    }

    private void FixedUpdate()
    {
        float velocityRatio = currentVelocity / maximumVelocity;
        float velocityCurveEvaluation = accelerationCurve.Evaluate(velocityRatio);
        float interpolatedVelocity = currentVelocity * velocityCurveEvaluation;

        Vector2 lastPosition = this.transform.position;
        Vector2 deltaPosition = lastPosition + interpolatedVelocity * directionVector * Time.deltaTime;

        float deltaVelocity = currentVelocity + accelerationRate * Time.deltaTime;
        this.currentVelocity = Mathf.Clamp(deltaVelocity, minimumVelocity, maximumVelocity);

        Quaternion lastRotation = this.transform.rotation;
        Quaternion deltaRotation = Quaternion.Slerp(lastRotation, maximumSteeringQuaternion, velocityRatio * steeringDumping);
        
        this.transform.position = deltaPosition;
        this.transform.rotation = deltaRotation;

        //flip
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        Vector3 spaceshipPosition = this.transform.position;
        float limit = width * 0.5f;
        float offset = 0.5f;

        if (spaceshipPosition.x > limit)
        {
            this.lineRenderer.enabled = false;
            spaceshipPosition.x = -limit + offset;
            this.transform.position = spaceshipPosition;
        }
        else if (spaceshipPosition.x < -limit)
        {
            this.lineRenderer.enabled = false;
            spaceshipPosition.x = limit - offset;
            this.transform.position = spaceshipPosition;
        }
        else
        {
            this.lineRenderer.enabled = true;
        }
    }

    public void ToggleDirection()
    {
        this.directionVector *= -1.0f;
        this.maximumSteeringQuaternion = Quaternion.Inverse(maximumSteeringQuaternion);
        currentVelocity = minimumVelocity;
    }
}
