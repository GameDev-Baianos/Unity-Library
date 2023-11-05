using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParentScript : MonoBehaviour
{
    public Animator animator;
    float delay = 0.3f;
    private bool attackDelay;

    public void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(attackDelay)
                return;
            
            animator.SetTrigger("isAttacking");
            attackDelay = true;

            StartCoroutine(DelayAttack());
        }
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackDelay = false;
    }
}
