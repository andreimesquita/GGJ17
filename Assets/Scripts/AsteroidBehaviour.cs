using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class AsteroidBehaviour : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private static float fallingVelocity = 2f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = Vector3.down * fallingVelocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Spaceship"))
        {
            int scorePoints = int.Parse(GameManager.Instance.entities.scoreText.text);
            scorePoints += (int) (transform.localScale.x * 1000);
            GameManager.Instance.entities.scoreText.text = scorePoints.ToString();
        }

        //TODO: shows up animation of the object being destroyed

        Destroy(this.gameObject);
    }
}