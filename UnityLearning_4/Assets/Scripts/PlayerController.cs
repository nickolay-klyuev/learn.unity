using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject powerupIndicator;

    private Rigidbody playerRb;

    private bool hasPowerup = false;
    private float powerupStrength = 500f;
    private float powerupTime = 7f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.AddForce(focalPoint.transform.forward * speed * Input.GetAxis("Vertical"));

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Powerup"))
        {
            Destroy(collider.gameObject);
            StopCoroutine(PowerupCountdown());
            StartCoroutine(PowerupCountdown());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdown()
    {
        hasPowerup = true;
        powerupIndicator.SetActive(true);

        yield return new WaitForSeconds(powerupTime);

        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
}
