using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private float force = 100f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.forward * Input.GetAxis("Vertical") * force);
        rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * force);
    }
}
