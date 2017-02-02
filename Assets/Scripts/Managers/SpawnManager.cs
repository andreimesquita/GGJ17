using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject asteroidPrefab;

        public static float MAX_X_POS
        {
            get { return Camera.main.aspect * 5; }
        }

        [Header("Spawn Configurations")]
        [SerializeField, Range(0, 5)]
        private float spawnDelay = 1;

        [SerializeField, Range(.05f, 2f)]
        private float minAsteroidScale, maxAsteroidScale;

        private float lastGameSpawnTime = 0;

        private void Awake()
        {
            if (!asteroidPrefab)
                Debug.LogError("'asteroidPrefab' not assigned!", this);
        }

        private void OnEnable()
        {
            lastGameSpawnTime = Time.time;
        }

        private void Update()
        {
            if (Time.time - lastGameSpawnTime >= spawnDelay)
            {
                GameObject newAsteroid = SpawnNewAsteroid();

                //Randomizes the asteroid's position
                newAsteroid.transform.position = transform.position + Vector3.right * Random.Range(-MAX_X_POS, MAX_X_POS);

                //Randomizes the asteroid's scale
                newAsteroid.transform.localScale = Vector3.one * Random.Range(minAsteroidScale, maxAsteroidScale);

                //Randomizes the asteroid's rotation
                newAsteroid.transform.localRotation = 
                    Quaternion.Euler(
                        Random.Range(-180, 180), 
                        Random.Range(-180, 180), 
                        Random.Range(-180, 180));

                lastGameSpawnTime = Time.time;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            float spacement = MAX_X_POS;

            if (!Application.isPlaying)
            {
                spacement *= Camera.main.aspect;
            }

            Gizmos.DrawLine(transform.position + -Vector3.right * spacement,
                transform.position + Vector3.right * spacement);
        }

        private GameObject SpawnNewAsteroid()
        {
            //TODO: Implement a descent spawn system
            return Instantiate(asteroidPrefab);
        }
    }
}