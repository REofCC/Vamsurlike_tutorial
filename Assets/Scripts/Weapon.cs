using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    PlayerController player;

    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;
    public float timer;
    public int penetrate;
    public int bulletSpeed;
    // Start is called before the first frame update

    void Awake()
    {
        player = GetComponentInParent<PlayerController>();
    }
    void Start()
    {
        Init();
    }
    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 150;    // 회전속도
                Batch();
                break;
            case 1:
                speed = 0.3f;    // 발사속도
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
                transform.Rotate(Vector3.back * speed * Time.deltaTime);    // 시계방향 회전
                break;
            case 1:
                timer += Time.deltaTime;

                if (timer > speed)
                {
                    timer = 0f;
                    Fire();
                }
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

            if (index < transform.childCount)   // 기존 생성된것 우선 사용
            {
                bullet = transform.GetChild(index);
            }
            else    // 없을 시 pool
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }

            bullet.localPosition = Vector3.zero;    // 초기화
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1, 0, Vector2.zero); // -1 = 관통 무한
        }
    }

    public void Fire()
    {
        if (!player.scanner.nearestTarget)
            return;

        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;


        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector2.up, dir); // 목표를 향해 회전
        bullet.GetComponent<Bullet>().Init(damage, penetrate, bulletSpeed, dir);
    }
}
