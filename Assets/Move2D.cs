using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public Rigidbody2D rb;
    public int moveSpeed;
    private float direction;

    private Vector3 facingRight;
    private Vector3 facingLeft;
    
    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask oQueEhChao;
    public int pulosExtras = 1;

    public Animator animator;

    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * (-1);

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            //esta correndo
            animator.SetBool("taCorrendo", true);
        }else
        {
            //esta parado
            animator.SetBool("taCorrendo", false);
        }

        taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, oQueEhChao);

        if(Input.GetButtonDown("Jump") && taNoChao == true)
        {
            rb.velocity = Vector2.up * 12;
            
            //ativar animação de pulo
            animator.SetBool("taPulando", true);
        }

        if(Input.GetButtonDown("Jump") && taNoChao == false && pulosExtras > 0)
        {
            rb.velocity = Vector2.up * 12;
            pulosExtras--;
        }

        if (taNoChao && rb.velocity.y == 0)
        {
            pulosExtras = 1;
            animator.SetBool("taPulando", false);
        }

        direction = Input.GetAxis("Horizontal");

        if(direction > 0)
        {
            // Olhando para direita.
            transform.localScale = facingRight;
        }

        if(direction < 0)
        {
            // Olhando para esquerda.
            transform.localScale = facingLeft;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("taAtacando", true);
        }else
        {
            animator.SetBool("taAtacando", false);
        }

        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }
}
