using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float spawnDelayTime = 2f;
    private float gameTime;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.realtimeSinceStartup - gameTime >= spawnDelayTime)
        {
            gameTime = Time.realtimeSinceStartup;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
