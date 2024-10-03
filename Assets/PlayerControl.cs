using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Camera sceneCam;
    public Rigidbody2D rb;
    public float moveSpeed;
    float sprint;
    private Vector2 moveDirection;
    private Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        sprint = Input.GetAxisRaw("Fire3");
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePos = sceneCam.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePos -rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x)*Mathf.Rad2Deg -90f;
        rb.rotation = aimAngle;
        if (sprint > 0)
        {
            moveSpeed = 10;
        }
        else
        {
            moveSpeed = 5;
        }
    }
}
