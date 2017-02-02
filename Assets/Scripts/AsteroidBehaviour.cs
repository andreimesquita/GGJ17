using Assets.Scripts.Managers;
using Assets.Scripts.So;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class AsteroidBehaviour : MonoBehaviour
    {
        [SerializeField]
        private AudioListSo audioListSo;

        private new Rigidbody rigidbody;
        private static float fallingVelocity = 2f;
        private AudioSource audioSource;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            AudioClip clip = audioListSo.AsteroidFallClip;

            audioSource.clip = clip;
            audioSource.PlayDelayed(fallingVelocity * 0.5f);
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
                float playerMultiplayer = GameManager.Instance.DeadPlayers == 1 ? 0.5f : 2.0f;
                scorePoints += (int)(transform.localScale.x * 1000 * playerMultiplayer);
                GameManager.Instance.entities.scoreText.text = scorePoints.ToString();
            }

            //TODO: shows up animation of the object being destroyed
        
            Destroy(this.gameObject);
        }

        private void OnEnable()
        {
            GameManager.Instance.GameOverNotification += AsteroidBehaviour_GameOverNotification;
        }

        private void OnDisable()
        {
            GameManager.Instance.GameOverNotification -= AsteroidBehaviour_GameOverNotification;
        }

        private void AsteroidBehaviour_GameOverNotification()
        {
            Destroy(this.gameObject);
        }
    }
}