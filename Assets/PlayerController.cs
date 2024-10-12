using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    private float jumpForce = 15;
    private float gravityModifier = 2;

    public bool isPlayerOnTheGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlayerOnTheGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isPlayerOnTheGround = false;
        }
    } 

    private void OnCollisionEnter(Collision collision)
    {
        isPlayerOnTheGround = true;
    }
}
