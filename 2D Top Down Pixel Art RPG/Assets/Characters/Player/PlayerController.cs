using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movementInput;

    private void Update()
    {
        //Player movement input
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        //Walking animations
        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y); 
        animator.SetFloat("Speed", movementInput.sqrMagnitude);

        //Idle and Attack animations
        if (movementInput.x == 1 || movementInput.x == -1 || movementInput.y == 1 || movementInput.y == -1)
        {
            animator.SetFloat("lastHori", movementInput.x);
            animator.SetFloat("lastVert", movementInput.y);
            animator.SetFloat("attackHori", movementInput.x);
            animator.SetFloat("attackVert", movementInput.y);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }    
}
