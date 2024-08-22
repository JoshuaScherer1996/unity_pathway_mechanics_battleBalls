using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Declaring and initializing the constants and variables.
    public GameObject enemyPrefab;
    private const float SpawnRange = 9.0f;
    
    // Start is called before the first frame update.
    private void Start()
    {
        SpawnWave(3);
    }
    
    // Handles the spawn position logic.
    private static Vector3 GenerateSpawnPos()
    {
        // Random x and y positions based on the spawn range.
        var spawnRangeX = Random.Range(-SpawnRange, SpawnRange);
        var spawnRangeZ = Random.Range(-SpawnRange, SpawnRange);

        // Generates a new random vector and returns it.
        var randomPos = new Vector3(spawnRangeX, 0, spawnRangeZ);
        return randomPos;
    }
    
    private void SpawnWave(int enemiesToSpawn)
    {
        // Loop that iterates 3 times.
        for (var i = 0; i < enemiesToSpawn; i++)
        {
            // Creates the enemy instance.
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
}
