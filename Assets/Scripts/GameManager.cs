using System.Data;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    

    [Header("Game Control")]
    public float currentGameTime;
    public float maxGameTime;

    [Header("Player Info")]
    public int level=1;
    public int kill;
    public int exp;
    public int[] nextExp = { 10, 20, 40, 80, 160 };
    public float hp;

    [Header("Game Object")]
    public PoolManager pool;
    public PlayerController player;


    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        currentGameTime += Time.deltaTime;
        
        if(currentGameTime > maxGameTime)
        {
            currentGameTime = maxGameTime;
        }
    }

    public void GetExp()
    {
        exp++;
        if (exp >= nextExp[level])
        {
            level++;
            exp = 0;
        }
    }
}
