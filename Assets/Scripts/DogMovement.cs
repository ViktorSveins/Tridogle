using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    Vector3 mousePosition;
    Vector2 move;
    Rigidbody2D rigidbody;
    public float speed = 100;

    void Start()
    {
        // Cursor.visible = false;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        move = Vector2.Lerp(transform.position, mousePosition, speed);
    }

    private void FixedUpdate() {
        rigidbody.MovePosition(move);    
    }
}
