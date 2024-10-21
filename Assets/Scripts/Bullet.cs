using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public void OnCollisionEnter2D(Collision2D col){
        switch(col.gameObject.tag){
            case "Wall":
            Destroy(gameObject, 0.25f);
            break;
            case "Enemy":
            col.gameObject.GetComponent<EnemyAI>().TakeDamage(1);
            Destroy(gameObject);
            break;
        }
    }
    public void OnTriggerEnter2D(Collider2D col){
        switch(col.gameObject.tag){
            case "Ghost":
            col.gameObject.GetComponent<EnemyAI>().TakeDamage(1);
            Destroy(gameObject);
            break;
            case "Laser":
            Destroy(gameObject);
            break;
        }
    }
}
