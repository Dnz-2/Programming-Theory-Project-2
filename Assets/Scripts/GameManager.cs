using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject boulderPrefab;

    public GameObject[] healingFoods;

    private bool boulderSpawnCD;
    public bool playerInFloor;
    private bool foodSpawnCD;

    // Start is called before the first frame update
    void Start()
    {
        boulderSpawnCD = false;
        playerInFloor = true;
        foodSpawnCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        BoulderSpawner(); // ABSTRACTION
        HealingFoodsSpawner(); // ABSTRACTION
    }

    private void BoulderSpawner()
    {
        if (boulderSpawnCD == false && playerInFloor == true) // Spawns boulders if the player is in the first floor
        {
            int randomPosZ = Random.Range(140, 240);

            Instantiate(boulderPrefab, new Vector3(-130, 10, randomPosZ), transform.rotation);
            boulderSpawnCD = true;
            StartCoroutine(BoulderCD());
        }
    }

    IEnumerator BoulderCD()
    {
        yield return new WaitForSeconds(1);
        boulderSpawnCD = false;
    }

    private void HealingFoodsSpawner()
    {
        Vector3 randomPos = new Vector3(Random.Range(-130, 130), 125, Random.Range(110, 450));
        int FoodIndex = Random.Range(0,healingFoods.Length);

        if(foodSpawnCD == false && playerInFloor == false)
        {
            Instantiate(healingFoods[FoodIndex], randomPos, transform.rotation);

            foodSpawnCD= true;
            StartCoroutine(FoodCooldown());
        }
    }

    IEnumerator FoodCooldown()
    {
        yield return new WaitForSeconds(20);
        foodSpawnCD = false;
    }
}
