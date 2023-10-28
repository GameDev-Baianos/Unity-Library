using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movementInput;

    private void Update()
    {
        //Movement input (x and y)
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        //Walking animations
        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y); 
        animator.SetFloat("Speed", movementInput.sqrMagnitude);

        //Idle animations
        if (movementInput.x == 1 || movementInput.x == -1 || movementInput.y == 1 || movementInput.y == -1)
        {
            animator.SetFloat("lastHori", movementInput.x);
            animator.SetFloat("lastVert", movementInput.y);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }    
}
