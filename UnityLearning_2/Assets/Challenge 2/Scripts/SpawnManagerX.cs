using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomBall());
    }

    IEnumerator SpawnRandomBall()
    {
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnInterval - 1f, spawnInterval + 1f));

            // Generate random ball index and random spawn position
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

            // instantiate ball at random spawn location
            GameObject ball = ballPrefabs[Random.Range(0, ballPrefabs.Length)];
            Instantiate(ball, spawnPos, ball.transform.rotation);
        }
    }
}
