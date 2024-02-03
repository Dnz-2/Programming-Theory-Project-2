using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip dashSound;

    private float HorizontalInput;
    private float VerticalInput;

    private float speed = 500.0f;
    private float jumpPower = 10000.0f;
    private float dashForce = 17000.0f;
    private float rotateSpeed = 30.0f;

    private bool isOnGround;
    private bool dashCD;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        dashCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); // ABSTRACTION
        JumpPlayer(); // ABSTRACTION
        DashPlayer(); // ABSTRACTION
    }

    private void MovePlayer()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(gameObject.transform.forward * VerticalInput * speed * Time.deltaTime, ForceMode.Impulse);
        // playerRb.AddForce(Vector3.right * HorizontalInput * speed * Time.deltaTime, ForceMode.Impulse);
        gameObject.transform.Rotate(Vector3.up * HorizontalInput * rotateSpeed * Time.deltaTime);
    }

    private void JumpPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpPower * Time.deltaTime,ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void DashPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !dashCD)
        {
            playerRb.AddForce(gameObject.transform.forward * dashForce * Time.deltaTime, ForceMode.Impulse);
            playerAudio.PlayOneShot(dashSound, 1.0f);


            dashCD = true;
            StartCoroutine(DashCoolDown());
        }
    }

    IEnumerator DashCoolDown()
    {
        yield return new WaitForSeconds(3);
        dashCD = false;
    }

    
}
