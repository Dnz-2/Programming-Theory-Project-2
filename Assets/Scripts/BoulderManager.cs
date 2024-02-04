using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderManager : MonoBehaviour
{
    private Rigidbody boulderRb;
    private float boulderSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        boulderRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        boulderRb.AddForce(Vector3.right * boulderSpeed *  Time.deltaTime, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall Bound"))
        {
            Destroy(gameObject);
        }
    }
}
