using JetBrains.Annotations;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;     // The enemy prefab to spawn
    public Transform[] spawnPoint;       // The point where enemies will be spawned
    public float initialSpawnRate = 2f; // Initial time between spawns
    public float spawnRateDecrease = 0.2f; // Rate at which spawn rate decreases
    public float minSpawnRate = 0.5f;   // Minimum time between spawns

    private float currentSpawnRate;     // The current time between spawns
    private float timer;                // Timer to track when to spawn the next enemy

    void Start()
    {
        currentSpawnRate = initialSpawnRate;
        timer = 0f;
    }

    void Update()
    {
        if(GameManager.Instance.StartGame)
        {
            // Update the timer
            timer += Time.deltaTime;

            // Check if it's time to spawn a new enemy
            if (timer >= currentSpawnRate)
            {
                SpawnEnemy();

                // Reset the timer
                timer = 0f;

                // Call a method to handle decreasing the spawn rate
               // DecreaseSpawnRate();
            }
        }
      
    }

    void SpawnEnemy()
    {
        int rand= Random.Range(0,enemyPrefab.Length);
        // Instantiate the enemy at the spawn point
        Instantiate(enemyPrefab[rand], spawnPoint[rand].position, Quaternion.identity);
    }

    void DecreaseSpawnRate()
    {
        // Decrease the spawn rate (but not below the minimum)
        currentSpawnRate = Mathf.Max(minSpawnRate, currentSpawnRate - spawnRateDecrease);
    }
}
