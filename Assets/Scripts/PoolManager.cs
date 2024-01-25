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
        pools = new List<GameObject>[prefabs.Length];   //prefab ������ŭ�� ����Ʈ ����

        for (int i = 0; i < pools.Length; i++)  //������ pool ����Ʈ �ȿ� ���� �� ����Ʈ ����
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
