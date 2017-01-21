using UnityEngine;

public class SpaceshipBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        this.gameObject.SetActive(false);
    }
}