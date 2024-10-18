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
        if(hp == 2){
            //add injured indication
        }
        if(hp == 1){
            //add injured indication
        }
        if(hp == 0){
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
