using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    Vector3 mousePosition;
    Vector2 nextPosition = new Vector2(0, 0);
    Rigidbody2D rb;
    public float speed = 0.1f;

    void Start()
    {
        // Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        nextPosition = Vector2.Lerp(transform.position, mousePosition, speed);
    }

    private void FixedUpdate() {
        rb.MovePosition(nextPosition);    
    }
}
