using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemySpawners;
    public GameObject[] enemies;
    
    public float spawnDelay = 1.0f;
    public float timer = 0.0f;
    public float smallAsteroidTimer = 0.0f;
    public int spawnSpecial = 0;
    void Start()
    {
        
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > spawnDelay)
        {
            int randomSpawner1 = Random.Range(0, enemySpawners.Length-1);
            Instantiate(enemies[0], enemySpawners[randomSpawner1].transform.position, enemySpawners[randomSpawner1].transform.rotation);
            timer = 0.0f;

            if (Random.Range(0,1) == 0) //50% to spawn special enemy, or additional enemy
            {
                int randomSpawner2 = randomSpawner1;
                while (randomSpawner1 == randomSpawner2)
                {
                    randomSpawner2 = Random.Range(0, enemySpawners.Length-1);
                }
                spawnSpecial = Random.Range(0, enemies.Length - 1);
                Instantiate(enemies[spawnSpecial], enemySpawners[randomSpawner2].transform.position, enemySpawners[randomSpawner2].transform.rotation);
            }
        }
    }
}
