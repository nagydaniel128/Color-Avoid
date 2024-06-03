using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //the prefab of the enemies to spawn
    public GameObject enemy;

    //resetting the spawner each time the game starts over
    void OnEnable()
    {
        timeNeeded = Random.Range(10, 20);
        maxTime = 60f;
        timer = 0;
    }

    //handling the cooldown of the enemy spawning, randomizing the next spawn time each time when a new enemy spawned, then spawn an enemy
    public float maxTime;
    int timeNeeded;
    int timer = 0;
    void FixedUpdate()
    {
        timer++;
        
        if (timer == timeNeeded)
        {
            timer = 0;
            timeNeeded = Random.Range(1, (int)maxTime);

            Instantiate(enemy, new Vector3(10, Random.Range(-5, 5), 0), Quaternion.identity);
        }
    }
}
