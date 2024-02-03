using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    private float HorizontalInput;
    private float VerticalInput;

    private float speed = 500.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * VerticalInput * speed * Time.deltaTime,ForceMode.Impulse);
        playerRb.AddForce(Vector3.right * HorizontalInput * speed * Time.deltaTime, ForceMode.Impulse);
    }
}
