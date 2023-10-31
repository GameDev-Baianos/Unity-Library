using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    
    public float runSpeed = 4f;
    float horzizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        horzizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(Input.GetButtonDown("Crouch"))
            crouch = true;
        else if(Input.GetButtonUp("Crouch"))
            crouch = false;
    }

    void FixedUpdate()
    {
        controller.Move(horzizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
