using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject boulderPrefab;

    private bool boulderSpawnCD;

    // Start is called before the first frame update
    void Start()
    {
        boulderSpawnCD = false;

    }

    // Update is called once per frame
    void Update()
    {
        BoulderSpawner(); // ABSTRACTION
    }

    private void BoulderSpawner()
    {
        if (boulderSpawnCD == false)
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
}
