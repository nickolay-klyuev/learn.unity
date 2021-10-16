using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftScript : MonoBehaviour
{
    private float moveSpeed = 10f;
    private float leftBoundX = -10f;

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.IsGameOver())
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (transform.position.x <= leftBoundX && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
