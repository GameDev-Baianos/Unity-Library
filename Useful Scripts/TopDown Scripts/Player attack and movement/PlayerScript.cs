using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Vector2 moveDelta;
    Rigidbody2D rb;
    private WeaponParentScript weaponParent;

    [SerializeField ]int moveSpeed;
    float ySpeed = 0.75f;
    float xSpeed = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weaponParent = GameObject.FindGameObjectWithTag("Sword").GetComponent<WeaponParentScript>();
    }
    
    void FixedUpdate()
    {
        MoveCharacter(); 
    }

    void Update()
    {
        weaponParent.Attack();
    }

     void MoveCharacter()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput  = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector2(xInput * xSpeed, yInput * ySpeed);
        moveDelta.Normalize();

        // move the RigidBody2D instead of moving the Transform
        rb.velocity = moveDelta * moveSpeed;

        // Swap sprite direction
        if(moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if(moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
