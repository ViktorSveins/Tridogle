using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rb;
    bool stop = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stop)
        {
            rb.velocity = new Vector2(Random.Range(-0.9f, 0.1f) * 100, Random.Range(-0.9f, 0.1f)) * 100;
            stop = false;
        }
    }

    void FixedUpdate() 
    {
    }
}
