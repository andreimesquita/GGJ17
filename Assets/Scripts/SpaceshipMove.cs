using DG.Tweening;
using System;
using System.Collections;
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
    [SerializeField] private float maximumSteeringAngle;
    //[SerializeField] private Timer timer;

    private Vector2 directionVector;
    private Quaternion maximumSteeringQuaternion;
    private float currentVelocity;
    private float defaultAccelerationRate;
    private bool isPresentationStep;
    private float presentationTime;

    private void Awake()
    {
        this.maximumVelocity = 6.0f;
        this.minimumVelocity = 1.0f;
        this.defaultAccelerationRate = 8.0f;
        this.accelerationRate = 0.0f;
        this.steeringDumping = 0.25f;

        this.directionVector = new Vector2(direction, 0.0f);
        this.maximumSteeringQuaternion = Quaternion.AngleAxis(maximumSteeringAngle, Vector3.forward);

        this.presentationTime = 2.5f;

        this.isPresentationStep = true;

        DOVirtual.DelayedCall(presentationTime, DisablePresentationStep);

        //timer.RegisterCallback(this.presentationTime, DisablePresentationStep);

        StartCoroutine(AccelerateGracefully());
    }

    private void DisablePresentationStep()
    {
        this.isPresentationStep = !this.isPresentationStep;
        this.accelerationRate = defaultAccelerationRate;
    }

    public IEnumerator AccelerateGracefully()
    {
        yield return new WaitForSeconds(this.presentationTime * 0.2f);

        this.accelerationRate = Mathf.Clamp(defaultAccelerationRate * 0.005f, accelerationRate, defaultAccelerationRate);
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

        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        float max = width * 0.5f;
        float min = -max;
        Vector3 position = this.transform.position;
        position.x = Mathf.Clamp(deltaPosition.x, min, max);

        if ((Math.Abs(position.x - max) < 0.001f) || Math.Abs(position.x - min) < 0.001f)
        {
            deltaRotation = Quaternion.identity;
        }

        this.transform.position = position;
        this.transform.rotation = deltaRotation;
    }

    public void ReverseInitialDirection()
    {
        if (isPresentationStep) return;

        this.directionVector = new Vector2(direction * -1.0f, 0.0f);
        this.maximumSteeringQuaternion = Quaternion.Inverse(maximumSteeringQuaternion);
        currentVelocity = minimumVelocity;
    }

    public void ResetDirection()
    {
        if (isPresentationStep) return;

        this.directionVector = new Vector2(direction, 0.0f);
        this.maximumSteeringQuaternion = Quaternion.AngleAxis(maximumSteeringAngle, Vector3.forward);
        currentVelocity = minimumVelocity;
    }
}
