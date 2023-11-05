using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptWithTranslate : MonoBehaviour
{
    Vector3 moveDelta;

    [SerializeField ]int moveSpeed;
    float ySpeed = 0.75f;
    float xSpeed = 1.0f;
    
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput  = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(xInput * xSpeed, yInput * ySpeed, 0);

        transform.Translate(moveDelta * moveSpeed * Time.deltaTime);
    }
}
