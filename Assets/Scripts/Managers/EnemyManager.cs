using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    [Header("Spawn after x seconds")]
    public int spawnRate;

    private float spawnCounter;

    private int nrOfSpawnPoints;

    private System.Random randomizer = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        nrOfSpawnPoints = spawnPoints.Length;
        SpawnNewEnemy();

        if (PlayerPrefs.GetString("activemod").Contains("Enemy Spawn Rate"))
        {
            spawnRate /= 2;
        }
        else
        {
            spawnCounter = spawnRate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCounter > 0)
        {
            spawnCounter -= Time.deltaTime;
        }
        else if (spawnCounter <= 0)
        {
            SpawnNewEnemy();
            spawnCounter = spawnRate;
        }
    }

    public void SpawnNewEnemy()
    {
        Instantiate(enemyPrefab, spawnPoints[Random.Range(0, nrOfSpawnPoints)].transform.position, Quaternion.identity);
    }
}
