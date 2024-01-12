using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;
    // Start is called before the first frame update

    void Start()
    {
        Init();
    }
    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 1;
                Batch();
                break;
            case 1:
                break;
            default:
                break;

        }
    }

    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);    // �ð���� ȸ��
                break;
            case 2:
                break;
            default:
                break;

        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if (id==0)
        {
            Batch();
        }
    }

    void Batch()
    {
        for (int index = 0; index < count; index++)
        {
            Transform bullet;

            if (index < transform.childCount)   // ���� �����Ȱ� �켱 ���
            {
                bullet = transform.GetChild(index);
            }
            else    // ���� �� pool
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }

            bullet.localPosition = Vector3.zero;    // �ʱ�ȭ
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1); // -1 = ���� ����
        }
    }
}