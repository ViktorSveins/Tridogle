using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rb;
    float maxMagnitude;
    float magLessener;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(Random.Range(-100.0f, -50.0f), Random.Range(-100.0f, -50.0f));
        rb.velocity = direction;
        maxMagnitude = 300.0f;
        magLessener = maxMagnitude * 0.75f;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        float magnitude = rb.velocity.magnitude;
        float change = Random.Range(10.0f, 50.0f);
        
        if(rb.velocity.x < 100.0f && rb.velocity.x > -100.0f)
        {
            if(rb.velocity.x < 0)
            {
                rb.velocity -= new Vector2(change, 0);
            }
            else 
            {
                rb.velocity += new Vector2(change, 0);
            }
        }
        else if(rb.velocity.y < 100.0f && rb.velocity.y > -100.0f)
        {
            if(rb.velocity.y < 0)
            {
                rb.velocity -= new Vector2(0, change);
            }
            else 
            {
                rb.velocity += new Vector2(0, change);
            }
        }
        else 
        {
            Vector2 normal = rb.velocity.normalized;
            float thrustFactor = 1.0f + (maxMagnitude - magnitude) / magLessener;

            rb.velocity *= thrustFactor;
        }
    }
}
