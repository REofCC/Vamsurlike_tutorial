using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Scanner scanner;

    private Rigidbody2D rigid;
    private SpriteRenderer sprite;
    [SerializeField]
    float moveSpeed;

    public Animator animator;
    public Vector2 inputVec;
    private WaitForFixedUpdate wait;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        scanner = GetComponent<Scanner>();
        wait = new WaitForFixedUpdate();
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)  // OnCollisionEnter 특징상 최초 접촉만 데미지, 추후 Stay로 변경 후 무적 시간 설정 필요
    {
        if (!collision.gameObject.CompareTag("Enemy") || !GameManager.instance.isAlive)
            return;

        StartCoroutine(Hit());

        GameManager.instance.hp -= collision.gameObject.GetComponent<Enemy>().damage;

        if (GameManager.instance.hp > 0)
        {
            //animator.SetTrigger("Hit");
        }
        else
        {
            GameManager.instance.isAlive = false;
            gameObject.SetActive(false);
        }

        Debug.Log("hit");
        // 피격 모션 및 무적 시간

    }
    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * moveSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }
    private void LateUpdate()
    {
        if (inputVec.x>0)
            sprite.flipX = true;
    }

    IEnumerator Hit()
    {
        yield return wait;
        
    }
}
