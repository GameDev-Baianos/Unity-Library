using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    public float moveSpeed;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset MoveDelta
        moveDelta = new Vector3(x, y, 0);

        // Swap sprite direction
        if(moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if(moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        /*
        // Make sure we can move in this direction by casting a box there first. If it returns null, we're free to move 
        hit = Physics2D.BoxCast(transform.position,
                                boxCollider.size, 
                                0, 
                                new Vector2(0 , moveDelta.y), 
                                Mathf.Abs(moveDelta.y * Time.fixedDeltaTime), 
                                LayerMask.GetMask("Characters", "Blocking"));

        if(hit.collider == null)
            transform.Translate(0, moveDelta.y * moveSpeed * Time.fixedDeltaTime, 0);   //Make it move

        hit = Physics2D.BoxCast(transform.position,
                                boxCollider.size, 
                                0, 
                                new Vector2(moveDelta.x, 0), 
                                Mathf.Abs(moveDelta.x * Time.fixedDeltaTime), 
                                LayerMask.GetMask("Characters", "Blocking"));
                                
        if(hit.collider == null)
            transform.Translate(moveDelta.x * moveSpeed * Time.fixedDeltaTime, 0, 0);
        */

        transform.Translate(moveDelta * moveSpeed * Time.fixedDeltaTime);
    }
}
