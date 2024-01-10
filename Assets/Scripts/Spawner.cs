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
    float basicSpawnRate;
    [SerializeField]
    float increaseSpawnRate;
    [SerializeField]
    int maxSpawnCount;
    [SerializeField]
    int maxlevel;

    public SpawnData[] spwanData;

    private int currentLevel;

    private float timer;


    void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        currentLevel = Mathf.FloorToInt(GameManager.instance.currentGameTime / (GameManager.instance.maxGameTime/maxlevel));   // ���� ��� �ð� / (�ִ� ���� �ð� / ���� �ܰ�) �� �������� ����
        if (timer > (currentLevel == 0 ? basicSpawnRate : basicSpawnRate - increaseSpawnRate * currentLevel)) // �⺻ ���� - (��·� * ����)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(Random.Range(0, GameManager.instance.pool.GetEnemyTypes()));
        enemy.transform.position = spawnPoints[Random.Range(1,spawnPoints.Length)].position;
    }
}
[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnRate;
    public int hp;
    public float moveSpeed;
}