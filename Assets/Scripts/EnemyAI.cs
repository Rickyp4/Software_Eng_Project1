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
    private Vector2 direction;
    private bool beingDirected = false;
    void Awake(){
        player = GameObject.FindWithTag("Player");
    }
    public void OnTriggerEnter2D(Collider2D col){
        switch(col.gameObject.tag){
            case "Direct":
            direction = col.transform.up;
            beingDirected = true;
            break;
        }
    }
    public void OnCollisionEnter2D(Collision2D col){
        switch(col.gameObject.tag){
            case "Player":
            col.gameObject.GetComponent<PlayerScript>().TakeDamage(1);
            break;
        }
    }
    public void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Direct"){
            beingDirected = false;
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp == 0){
            player.GetComponent<PlayerScript>().GiveSoul(soulValue);
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        Move();
        if(!beingDirected){
            direction = player.transform.position - transform.position;
            direction.Normalize();
        }
    }
    void Move()
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
}
