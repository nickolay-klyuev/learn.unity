using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerupPrefab;

    private float spawnRange = 9f;
    private int enemiesCount;
    private int waveCount = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        return new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
    }

    // Update is called once per frame
    void Update()
    {
        enemiesCount = GameObject.FindObjectsOfType<EnemyController>().Length;

        if (enemiesCount == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            SpawnEnemies(waveCount);
            waveCount++;
        }
    }
}
