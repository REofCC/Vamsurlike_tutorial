using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField]
    float spawnRate;
    [SerializeField]
    int maxSpawnCount;

    private float timer;


    void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer> spawnRate)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, GameManager.instance.pool.GetEnemyTypes()));
        enemy.transform.position = spawnPoints[Random.Range(1,spawnPoints.Length)].position;
    }
}
