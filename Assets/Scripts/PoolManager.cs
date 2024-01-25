using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;

    List<GameObject>[] pools;
    // Start is called before the first frame update
    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];   //prefab 갯수만큼의 리스트 생성

        for (int i = 0; i < pools.Length; i++)  //생성된 pool 리스트 안에 각각 새 리스트 생성
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in pools[index])
        {
            if ( !item.activeSelf )
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        if(!select)
        {
            select = Instantiate(prefabs[index],transform);
            pools[index].Add(select);
        }

        return select;
    }

    public int GetEnemyTypes()
    {
        return prefabs.Length;
    }
    
}
