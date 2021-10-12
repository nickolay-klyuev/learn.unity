using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float maxBound = 40f;
    [SerializeField] private float minBound = -15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float z = transform.position.z;
        if (z >= maxBound || z <= minBound)
        {
            Destroy(gameObject);
        }
    }
}
