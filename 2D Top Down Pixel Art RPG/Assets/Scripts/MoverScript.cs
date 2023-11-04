using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoverScript : FigtherScript
{
    private Vector3 moveDelta;
    public float moveSpeed;
    protected float ySpeed = 0.75f;
    protected float xSPeed = 1.0f;

    protected virtual void UpdateMotor(Vector3 input)
    {
        // Reset MoveDelta
        moveDelta = new Vector3(input.x * xSPeed, input.y * ySpeed, 0);

        // Swap sprite direction
        if(moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if(moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        transform.Translate(moveDelta * moveSpeed * Time.fixedDeltaTime);
    }
}
