using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAnimation : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int BOOL = 0;
    private Animator anim;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded == true)
        {
            BOOL = 1;
           // anim.SetTrigger("takeOf");
           

        }
        else BOOL = 0;
        if (isGrounded == true)
        {
            BOOL = 3;
            anim.SetBool("isDown", false);

        }
        else
        {
            BOOL = 4;
            anim.SetBool("isDown", true);
        }



    }
}
