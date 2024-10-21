using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    public static HealthPickup instance;

    public GameObject player;

    public void Awake(){
        if (instance == null){
            instance = this;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            Destroy(gameObject);
        }

        switch(collision.gameObject.tag){
            case "Player":
            collision.gameObject.GetComponent<PlayerScript>().TakeDamage(-1);
            break;
        }
    }
}
