using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 10f;
    public Vector3 direction;

    Animator pAnimator;
    Rigidbody2D pRig2D;
    SpriteRenderer sp;
    void Start()
    {
        pAnimator = GetComponent<Animator>();
        pRig2D = GetComponent<Rigidbody2D>();   
        sp = GetComponent<SpriteRenderer>();
        direction = Vector2.zero; //���� �ʱ�ȭ
    }
    void KeyInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal"); // -1 0 1
        if(direction.x < 0)
        {
            //left
            sp.flipX = true;
        }
        else if (direction.x > 0)
        {
            //right
            sp.flipX = false;
        }
        //else if (direction.x == 0)
        //{
        //    sp.flipX = false;
        //}
        // ���� �Է� (Update���� �޾ƾ� �Է��� ������ ����)
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    void Move()
    {
        // īŸ�� ���� Ư���� �ﰢ���� �̵�/���� ����
        // y���� �����ϰ� x���� �Է¿� ���� ������ ����
        pRig2D.linearVelocity = new Vector2(direction.x * speed, pRig2D.linearVelocity.y);
    }

    void Jump()
    {
        // �ܼ� ���� ���� (�ٴ� üũ ������ ���ܵ� ����)
        pRig2D.linearVelocity = new Vector2(pRig2D.linearVelocity.x, jumpForce);
    }
    void Update()
    {
        KeyInput();
    }
    void FixedUpdate()
    {
        Move();
    }
}
