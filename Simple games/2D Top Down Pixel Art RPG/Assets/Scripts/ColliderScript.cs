using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update()
    {
        //Colision work
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i] == null)
                continue;

            OnCollide(hits[i]);

            // The array is not cleaned up, do it yourself
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log("OnCollide was not implemented in " + this.name);
    }
}
