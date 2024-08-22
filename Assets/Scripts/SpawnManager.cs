using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    // Declaring and initializing the constants and variables.
    public GameObject enemyPrefab;
    private const float SpawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    
    // Start is called before the first frame update.
    private void Start()
    {
        SpawnWave(waveNumber);
    }

    // Update is called once per frame.
    private void Update()
    {
        // Finds all objects with the Enemy script attached.
        enemyCount = FindObjectsOfType<Enemy>().Length;
        
        // Logic to spawn new enemies once all current enemies are destroyed.
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnWave(waveNumber);
        }
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
        // Loop that iterates as many times as the value of enemiesToSpawn.
        for (var i = 0; i < enemiesToSpawn; i++)
        {
            // Creates the enemy instance.
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
}
