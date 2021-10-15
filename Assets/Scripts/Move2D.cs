using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private Rigidbody2D rig;

    public bool isJumping;
    public bool doubleJump;

    private Animator anim;

    private Vector3 facingRight;
    private Vector3 facingLeft;

    void Start()
    {
        //new Start
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * (-1);
    }

    void Update()
    {
        //new Update
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement *Time.deltaTime * speed;

        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("taCorrendo", true);
            transform.localScale = facingRight;
        }

        if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("taCorrendo", true);
            transform.localScale = facingLeft;

        }
        
        if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("taCorrendo", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rig.AddForce(new Vector2 (0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;

                anim.SetBool("taPulando", true);
            }
            else
            {
                if (doubleJump)
                {
                    rig.AddForce(new Vector2 (0f, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }

            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = false;
            anim.SetBool("taPulando", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isJumping = true;
        }
    }

    void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("taAtacando", true);
        }
        else
        {
            anim.SetBool("taAtacando", false);
        }
    }


//     public Rigidbody2D rb;
//     public int moveSpeed;
//     private float direction;

//     private Vector3 facingRight;
//     private Vector3 facingLeft;
    
//     public bool taNoChao;
//     public Transform detectaChao;
//     public LayerMask oQueEhChao;
//     public int pulosExtras = 1;

//     public Animator animator;

//     void Start()
//     {
//         facingRight = transform.localScale;
//         facingLeft = transform.localScale;
//         facingLeft.x = facingLeft.x * (-1);

//         rb = GetComponent<Rigidbody2D>();

//         animator = GetComponent<Animator>();
//     }

//     void Update()
//     {
//         if(Input.GetAxis("Horizontal") != 0)
//         {
//             //esta correndo
//             animator.SetBool("taCorrendo", true);
//         }else
//         {
//             //esta parado
//             animator.SetBool("taCorrendo", false);
//         }

//         taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, oQueEhChao);

//         if(Input.GetButtonDown("Jump") && taNoChao == true)
//         {
//             rb.velocity = Vector2.up * 12;
            
//             //ativar animação de pulo
//             animator.SetBool("taPulando", true);
//         }

//         if(Input.GetButtonDown("Jump") && taNoChao == false && pulosExtras > 0)
//         {
//             rb.velocity = Vector2.up * 12;
//             pulosExtras--;
//         }

//         if (taNoChao && rb.velocity.y == 0)
//         {
//             pulosExtras = 1;
//             animator.SetBool("taPulando", false);
//         }

//         direction = Input.GetAxis("Horizontal");

//         if(direction > 0)
//         {
//             // Olhando para direita.
//             transform.localScale = facingRight;
//         }

//         if(direction < 0)
//         {
//             // Olhando para esquerda.
//             transform.localScale = facingLeft;
//         }

//         if(Input.GetButtonDown("Fire1"))
//         {
//             animator.SetBool("taAtacando", true);
//         }else
//         {
//             animator.SetBool("taAtacando", false);
//         }

//         rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
//     }
}
