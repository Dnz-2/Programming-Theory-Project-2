using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFloorGoods : MonoBehaviour
{
    public PlayerHealth PlayerHealth;

    // Start is called before the first frame update
    public void Start()
    {
        PlayerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealPlayer();
            Destroy(gameObject);
        }
    }

    public virtual void HealPlayer()
    {
        PlayerHealth.health += 1;
    }
}
