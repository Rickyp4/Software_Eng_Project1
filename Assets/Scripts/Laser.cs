using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public SpriteRenderer sr;
    public float flickerRate;
    private float oppacity;
    private bool brighten = true;
    void Update()
    {
        if(brighten){
            oppacity += Time.deltaTime*flickerRate;
            if(oppacity >= 0.5f){
                brighten = false;
            }
        }
        if(!brighten){
            oppacity -= Time.deltaTime*flickerRate;
            if(oppacity <= 0.2f){
                brighten = true;
            }
        }
        sr.color = new Color(1, 0, 0, oppacity);
    }
    public void OnTriggerEnter2D(Collider2D col){
        switch(col.gameObject.tag){
            case "Enemy":
            col.gameObject.GetComponent<EnemyAI>().TakeDamage(10);
            break;
            case "Player":
            col.gameObject.GetComponent<PlayerScript>().TakeDamage(1);
            break;
        }
    }
}
