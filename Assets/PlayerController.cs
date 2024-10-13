using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionSmokeParticle;
    public ParticleSystem dirtSplatterParicle;
    private float jumpForce = 900;
    private float gravityModifier = 2;
    public bool gameOver = false;
    private bool isPlayerOnTheGround = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerOnTheGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isPlayerOnTheGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtSplatterParicle.Stop();
        }
    } 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isPlayerOnTheGround = true;
            dirtSplatterParicle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            explosionSmokeParticle.Play();
            dirtSplatterParicle.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            gameOver = true;

        }

    }
}
