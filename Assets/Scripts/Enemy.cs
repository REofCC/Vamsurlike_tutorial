using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float hp;
    [SerializeField]
    float MaxHp;
    [SerializeField]
    bool isAlive;

    public float damage;

    public Rigidbody2D target;

    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    private Animator animator;

    private WaitForFixedUpdate wait;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isAlive = true;
        wait = new WaitForFixedUpdate();    // 다음 물리 프레임까지 딜레이
    }
    void FixedUpdate()
    {
        if (!isAlive || animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            return;

        Vector2 vecDiff = target.position - rigid.position;
        Vector2 nextVec = vecDiff.normalized * moveSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        //스프라이트 flip추가
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet") || !isAlive) 
            return;

        hp -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack());
        if (hp >0)
        {
            animator.SetTrigger("Hit");
        }
        else
        {
            isAlive = false;
            gameObject.SetActive(false);
            GameManager.instance.kill++;
            GameManager.instance.GetExp();

        }
           
    }

    IEnumerator KnockBack()
    {
        yield return wait;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse); //3은 추후 넉백 파워로 교체
    }
    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isAlive = true;
        hp = MaxHp;
    }

    public void Init(SpawnData data)
    {
        moveSpeed = data.moveSpeed;
        hp = data.hp;
        MaxHp = data.hp;
        damage = data.damage;
    }


}
