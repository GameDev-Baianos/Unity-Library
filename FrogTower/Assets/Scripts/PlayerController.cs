using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveDelta;
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField ]int moveSpeed;
    float ySpeed = 0.75f;
    float xSpeed = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        MoveCharacter(); 
    }

     void MoveCharacter()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput  = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector2(xInput * xSpeed, yInput * ySpeed);
        moveDelta.Normalize();

        // move the RigidBody2D instead of moving the Transform
        rb.velocity = moveDelta * moveSpeed;
    }
}
