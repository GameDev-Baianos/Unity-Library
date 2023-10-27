using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    public Rigidbody2D rb;

    Vector2 movementInput;

    private void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }    
}
