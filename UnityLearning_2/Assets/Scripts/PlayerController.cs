using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float moveSpeed = 10f;

    private float horizontalInput;
    private Transform thisTransform;

    private float xRange = 10f;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // fire projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, thisTransform.position, Quaternion.identity);
        }

        // move player within bounds
        if (thisTransform.position.x <= xRange && thisTransform.position.x >= -xRange)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            thisTransform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);
        }
        else if (thisTransform.position.x >= xRange)
        {
            thisTransform.position = new Vector3(xRange, thisTransform.position.y, thisTransform.position.z);
        }
        else if (thisTransform.position.x <= -xRange)
        {
            thisTransform.position = new Vector3(-xRange, thisTransform.position.y, thisTransform.position.z);
        }
    }
}
