using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject[] prizes;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    public float timeBetweenSpawnPrize;
    private float spawnTime;
    private float spawnTimePrize;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime) {
            SpawnObstacle();
            spawnTime = Time.time + timeBetweenSpawn;
        }
        if (Time.time > spawnTimePrize) {
            SpawnPrize();
            spawnTimePrize = Time.time + timeBetweenSpawnPrize;
        }
    }

    void SpawnObstacle() {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }

    void SpawnPrize() {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        int random = Random.Range(0,2);

        Instantiate(prizes[random], transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
