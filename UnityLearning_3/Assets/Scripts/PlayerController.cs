using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityMod;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

    private Rigidbody playerRb;
    private Animator playerAnimator;
    private AudioSource playerAudio;
    private bool isOnGround = true;
    static private bool gameOver = false;
    static public bool IsGameOver()
    {
        return gameOver;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1f);
            playerAnimator.SetTrigger("Jump_trig");
            isOnGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            dirtParticle.Play();
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1f);
            explosionParticle.Play();
            playerAnimator.SetInteger("DeathType_int", 1);
            playerAnimator.SetBool("Death_b", true);
        }
    }
}
