using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    private Vector3 spawnPos = new Vector3(30, 0, 0);

    private float startDelay = 2f;
    private float repeatRate = 2f;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(startDelay);

        while (!PlayerController.IsGameOver())
        {
            Instantiate(spawnObject, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(repeatRate);
        }
    }
}
