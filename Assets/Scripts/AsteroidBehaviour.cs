using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AsteroidBehaviour : MonoBehaviour
{
    private new Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = Vector3.down * SpawnManager.fallingVelocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        //TODO: shows up animation of the object being destroyed

        Destroy(this.gameObject);
    }
}