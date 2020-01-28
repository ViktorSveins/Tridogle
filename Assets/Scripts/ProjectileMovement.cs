using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(Random.Range(-200.0f, -100.0f), Random.Range(-200.0f, -100.0f));
        rb.velocity = direction;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        rb.velocity *= 1.1f; 
        if(col.gameObject.tag == "Wall")
        {
        }
    }
}
