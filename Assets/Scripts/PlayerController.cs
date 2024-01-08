using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField]
    float moveSpeed;

    public Vector2 inputVec;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
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
}
