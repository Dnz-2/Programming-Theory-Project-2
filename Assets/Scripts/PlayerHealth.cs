using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    private bool hitCooldown;

    public Behaviour playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        hitCooldown = false;
    }

    private void Update()
    {
        HealhAlwaysPositive(); // ABSTRACTION
        IsCharacterAlive(); // ABSTRACTION
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boulder") && !hitCooldown)
        {
            health = health - 2;
            hitCooldown = true;
            StartCoroutine(Iframes());
        }
    }

    IEnumerator Iframes()
    {
        yield return new WaitForSeconds(1);
        hitCooldown=false;
    }

    private void HealhAlwaysPositive()
    {
        if(health < 0)
        {
            health = 0;
        }
    }

    private void IsCharacterAlive()
    {
        if(health == 0)
        {
            playerMovement.enabled = false;
        }
    }
}
