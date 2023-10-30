using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SlimeScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject sender;
    
    public float strength = 3, delay = 0.15f; 
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void knockBack()
    {
        StopAllCoroutines();
        sender = GameObject.FindWithTag("Sword");
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector2.zero;
    }

    public void TakeDamage(int damage)
    {
        knockBack();
        currentHealth -= damage;

        //Play hurt animation
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);
        Destroy(gameObject, 0.5f);
    }
}
