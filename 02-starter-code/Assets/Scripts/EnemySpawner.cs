using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy enemyPrefab;
        public float spawnInterval = 2;
        public int maxEnemies = 20;
    }

    public Transform[] waypoints;
    public Wave[] waves; // The definition of all our waves (will be set in-editor)
    public int currentWaveIndex = 0;
    public int timeBetweenWaves = 5;

    // Events
    public UnityEvent OnWaveStarted = new UnityEvent();

    IEnumerator Start()
    {
        // Current wave index will be incremented once we've spawned all the enemies for this wave.
        while (currentWaveIndex < waves.Length)
        {
            OnWaveStarted?.Invoke(); // Fire an event that we'll hook into later.
            for (var i = 0; i < waves[currentWaveIndex].maxEnemies; i++)
            {
                // Spawn an enemy, then wait for the spawn interval before continuing.
                SpawnEnemy();
                yield return new WaitForSeconds(waves[currentWaveIndex].spawnInterval);
            }
            // Increment the current wave index. You could also write a for loop rather than a while loop if you prefer.
            currentWaveIndex++;
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    public void SpawnEnemy()
    {
        // Looks at the current wave to determine which enemy we should spawn.
        Enemy newEnemy = Instantiate(waves[currentWaveIndex].enemyPrefab, transform.position, Quaternion.identity);
        newEnemy.waypoints = waypoints;
    }
}
