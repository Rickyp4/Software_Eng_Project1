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
    private Vector2 direction;
    private bool beingDirected = false;
    void Awake(){
        player = GameObject.FindWithTag("Player");
    }
    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Direct"){
            direction = col.transform.up;
            beingDirected = true;
        }
    }
    public void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Direct"){
            beingDirected = false;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {

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
