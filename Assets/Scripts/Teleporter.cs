using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0,1,0)); // rotates the teleporter
    }

    private void OnTriggerEnter(Collider other) // teleports player to second floor and stops first floor trap
    {
        other.transform.position = new Vector3(0, 48.5f, 265.31f);
        gameManager.playerInFloor = false;
    }
}
