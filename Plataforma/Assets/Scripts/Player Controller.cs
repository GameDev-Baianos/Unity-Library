using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform player;
    [SerializeField] float vel = 5f;
    [SerializeField] float Jforce = 10f;
    [SerializeField] bool isGrounded;
    [SerializeField] bool doubleJump;
    [SerializeField] bool direction;
    [SerializeField] float dashForce = 10f;
    [SerializeField] bool canDash = true;
    [SerializeField] bool isDashing = false;
    [SerializeField] float dashTime = 0.2f;
    [SerializeField] float dashCooldown = 1f;
    [SerializeField] TrailRenderer tr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        tr = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        Movement();
        Debug.Log(rb.velocity.y);
        // Pular
        if(Input.GetButtonDown("Jump") && isGrounded && !isDashing)
        {
            rb.velocity = (new Vector2(rb.velocity.x, Jforce));
            doubleJump = true;
        }
        else if(Input.GetButtonDown("Jump") && doubleJump && !isDashing)
        {
            rb.velocity = (new Vector2(rb.velocity.x, Jforce));
            doubleJump = false;
        }

        // Dash
        if(Input.GetButtonDown("Dash") && canDash)
        {
            StartCoroutine(Dash());
        }
        
    }

    void Movement ()
    {
        if(Input.GetButton("Horizontal") && !isDashing)
        {
            Vector3 movement = new Vector3 (Input.GetAxis("Horizontal"), 0, 0);
            transform.position += movement * Time.deltaTime * vel;
        }
        // Verificar para qual lado o jogador esta olhando e definir a direção do dash
        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            direction = true;
            if(dashForce < 0)
            {
                dashForce = dashForce * -1;
            }
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            direction = false;
            if(dashForce > 0)
            {
                dashForce = dashForce * -1;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D ground)
    {
        if(ground.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D grund) 
    {
        if(grund.gameObject.layer == 8)
        {
        isGrounded = false;
        }
    }
        
    private IEnumerator Dash()
    {
        // boa sorte
        canDash = false;
        isDashing = true;
        float gravidadePadrão = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashForce, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        rb.velocity = new Vector2(0f, 0f);
        tr.emitting = false;
        rb.gravityScale = gravidadePadrão;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

}
