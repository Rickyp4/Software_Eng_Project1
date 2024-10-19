using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Camera sceneCam;
    public Rigidbody2D rb;
    public float moveSpeed;
    public int hp;
    public int souls = 0;
    public SpriteRenderer characterSprite;
    private Vector2 moveDirection;
    private Vector2 mousePos;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp == 2){
            characterSprite.color = new Color(0.61f, 0.2f, 0.78f);
        }
        if(hp == 1){
            characterSprite.color = new Color(0.78f, 0.2f, 0.4f);
        }
        if(hp == 0){
            SceneManager.LoadScene("GameOver");
        }
    }
    public void GiveSoul(int soul){
        souls += soul;
        if(souls == 3){
            characterSprite.color = Color.red;
        }
    }
    public int GetSouls(int checkSouls, int takeSouls = 0){
        if(souls < checkSouls){
            return -1;
        }
        else{
            int surplus = souls - checkSouls;
            souls -= takeSouls;
            return surplus;
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
