using System.Data;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

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
    public float maxHp;
    public bool isAlive;

    [Header("Game Object")]
    public PoolManager pool;
    public PlayerController player;


    void Awake()
    {
        instance = this;
        this.hp = this.maxHp;
        this.isAlive = true;
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
            instance.player.GetComponentInChildren<Weapon>().LevelUp(1,1);
            exp = 0;
        }
    }
}
