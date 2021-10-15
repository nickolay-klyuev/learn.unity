using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftScript : MonoBehaviour
{
    private float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}