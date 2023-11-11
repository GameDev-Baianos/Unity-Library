using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveX;
    private float moveSpeed = 6.0f;

    private bool jump;
    private float jumpForce = 6.0f;

    // Is Grounged Variables
    public bool isGrounded;
    public Transform feetPosition;
    public float sizeRadius;
    public LayerMask whatIsGround;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {   
        // identify ground
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, sizeRadius, whatIsGround);

        moveX = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded)
            jump = true;

        // Flip sprite
        if(moveX < 0)
            spriteRenderer.flipX = true;
        else if (moveX > 0)
            spriteRenderer.flipX = false;

        // Jumping and Falling Animation  
        if(isGrounded)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);

            if(rb.velocity.x != 0 && moveX != 0)
                animator.SetBool("isMoving", true);
            else
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", false);

            if (rb.velocity.y > 0)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", false);
            }
            if (rb.velocity.y < 0)
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", true);
            }
        }
    }

    void FixedUpdate()
    {
        // Character Movement
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        // Character jump
        if(jump)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jump = false;
        }
    }
}
