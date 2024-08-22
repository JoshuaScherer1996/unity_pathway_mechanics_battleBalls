using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private const float SpawnRange = 9.0f;
    
    // Start is called before the first frame update.
    private void Start()
    {
        var spawnRangeX = Random.Range(-SpawnRange, SpawnRange);
        var spawnRangeZ = Random.Range(-SpawnRange, SpawnRange);

        var randomPos = new Vector3(spawnRangeX, 0, spawnRangeZ);
        
        Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
    }
}
