using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalsPrefabs;
    [SerializeField] private float initialDelay = 2f;
    [SerializeField] private float spawnInterval = 1.5f;

    private float spawnRangeX = 10f;
    private float spawnZ = 35f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", initialDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomAnimal()
    {
        GameObject animal = animalsPrefabs[Random.Range(0, animalsPrefabs.Length)];
        Instantiate(animal, new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnZ), animal.transform.rotation);
    }
}
