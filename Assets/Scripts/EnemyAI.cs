using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;
public class EnemyAI : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public GameObject player;
    public int hp;
    public int soulValue;
    public bool facePlayer;
    private Vector2 playerDirection;
    private Vector2 moveDirection;
    private bool beingDirected = false;
    private GameObject director;
    void Awake(){
        player = GameObject.FindWithTag("Player");
    }
    public void OnTriggerEnter2D(Collider2D col){
        switch(col.gameObject.tag){
            case "Direct":
            if(!gameObject.CompareTag("Ghost"))
            {
                director = col.gameObject;
                beingDirected = true;
            }
            break;
            case "Player":
            col.gameObject.GetComponent<PlayerScript>().TakeDamage(1);
            moveDirection *= -5;
            break;
        }
    }
    public void OnCollisionEnter2D(Collision2D col){
        switch(col.gameObject.tag){
            case "Player":
            col.gameObject.GetComponent<PlayerScript>().TakeDamage(1);
            moveDirection *= -5;
            break;
        }
    }
    public void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.CompareTag("Direct"))
        {
            beingDirected = false;
            director = null;
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0){
            if(soulValue > 0){
                player.GetComponent<PlayerScript>().GiveSoul(soulValue);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<Collider2D>().enabled=false;
                SoundFX.instance.PlaySting(gameObject.transform, 1f, gameObject);
            }
            else{
                Destroy(gameObject);
            }
        }
    }
    void FixedUpdate()
    {
        Move();
        playerDirection = (player.transform.position - transform.position).normalized;
        if(beingDirected){
            moveDirection = new Vector2(playerDirection.x + director.transform.up.normalized.x*2, playerDirection.y + director.transform.up.normalized.y*2).normalized;
        }
        else{
            moveDirection = playerDirection;
        }
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        if(facePlayer){
            float aimAngle = Mathf.Atan2(moveDirection.y, moveDirection.x)*Mathf.Rad2Deg -90f;
            rb.rotation = aimAngle;
        }
    }
}
