using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject asteroidPrefab;

        [Header("Position"), SerializeField, Range(0, 4)]
        private float spawnXSpacement;

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
                newAsteroid.transform.position = transform.position + Vector3.right * Random.Range(-spawnXSpacement, spawnXSpacement);

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

            Gizmos.DrawLine(transform.position + -Vector3.right * spawnXSpacement,
                transform.position + Vector3.right * spawnXSpacement);
        }

        private GameObject SpawnNewAsteroid()
        {
            //TODO: Implement a descent spawn system
            return Instantiate(asteroidPrefab);
        }
    }
}