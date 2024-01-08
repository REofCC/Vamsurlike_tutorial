using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    bool isAlive;
    public Rigidbody2D target;

    private Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        isAlive = true;
    }

    void FixedUpdate()
    {
        if (!isAlive)
            return;

        Vector2 vecDiff = target.position - rigid.position;
        Vector2 nextVec = vecDiff.normalized * moveSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

}
