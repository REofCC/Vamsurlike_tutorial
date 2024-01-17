using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int penetrate;
    public float speed;
    public Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    public void Init(float damage, int penetrate, float speed, Vector2 dir)
    {
        this.damage = damage;
        this.penetrate = penetrate;
        this.speed = speed;

        if (penetrate > -1 ) 
        {
            rigid.velocity = dir * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || penetrate == -1) 
            return;

        penetrate--;

        if (penetrate == 0)
        {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }
}
