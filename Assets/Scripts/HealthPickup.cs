using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(-1);
            Destroy(gameObject);
        }
    }
}
