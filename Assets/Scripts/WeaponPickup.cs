using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            Destroy(gameObject);
        }
    }

    
}
