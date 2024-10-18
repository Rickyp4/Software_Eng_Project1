using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Camera sceneCam;
    public Rigidbody2D rb;
    public float moveSpeed;
    public Gun gun;
    public int hp;
    private Vector2 moveDirection;
    private Vector2 mousePos;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp == 0){
            SceneManager.LoadScene("GameOver");
        }
    }
    void Update()
    {
        if(!PauseMenu.isPaused){
            ProcessInputs();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0)){
            gun.Fire();
        }
        moveDirection = new Vector2(moveX, moveY);
        mousePos = sceneCam.ScreenToWorldPoint(Input.mousePosition);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePos -rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x)*Mathf.Rad2Deg -90f;
        rb.rotation = aimAngle;
    }
}
