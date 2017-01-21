using UnityEngine;

public interface ISpaceshipMoviment
{
    void ApplyDirection(Vector2 direction, float force);

    void UnapplyDirection();
}

public class SpaceshipMoviment : MonoBehaviour, ISpaceshipMoviment
{
    [SerializeField] private readonly Vector2 defaultDirection;
    [SerializeField] private float maximumForce;
    [SerializeField] private float maximumSteeringAngle;
    [SerializeField] private float steeringDamping;

    private Vector2 direction;
    private float force;

    public SpaceshipMoviment()
    {
        this.defaultDirection = Vector2.left;
        this.maximumSteeringAngle = 45.0f;
        this.maximumForce = 1.0f;
        this.steeringDamping = 20.0f;
    }

    public void ApplyForce(Vector2 direction)
    {
        ApplyDirection(direction, 1.0f);
    }

    public void ApplyDirection(Vector2 direction, float force)
    {
        this.direction = direction;
        this.force = force;
    }

    public void UnapplyDirection()
    {
        this.direction = Vector2.zero;
        this.force = 1.0f;
    }

    public void Update()
    {
        this.transform.rotation = CalculateRotation();
        this.transform.position = CalculatePosition();
    }

    private Vector2 CalculatePosition()
    {
        Vector2 position = this.transform.position;
        Vector2 direction = this.direction == Vector2.zero ? defaultDirection : this.direction;
        float forceClamped = Mathf.Clamp(this.force, this.maximumForce, 1.0f);

        return position + direction * forceClamped * Time.deltaTime;
    }

    private Quaternion CalculateRotation()
    {
        float angle = Mathf.MoveTowardsAngle(this.transform.eulerAngles.z, maximumSteeringAngle, steeringDamping * Time.deltaTime);

        return Quaternion.AngleAxis(angle, this.transform.forward);
    }
}