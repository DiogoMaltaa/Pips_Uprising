using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    GameObject selectedEnemie;

    public Transform[] spawns;
    Transform selectedSpawn;

    bool canSpawn;

    public float spawnTimer;
    float timer;


    // Update is called once per frame
    void Update()
    {
        spawnTimer = Random.Range(3, 9);
        selectedEnemie = enemies[Random.Range(0, enemies.Length)];
        selectedSpawn = spawns[Random.Range(0, spawns.Length)];

        if (!canSpawn)
        {
            timer += Time.deltaTime;

            if(timer > spawnTimer)
            {
                canSpawn = true;
                timer = 0;
            }
        }

        if (canSpawn)
        {
            Instantiate(selectedEnemie, selectedSpawn.position, Quaternion.identity);
            canSpawn = false;
        }

    }
}
