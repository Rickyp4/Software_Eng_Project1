using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public SpriteRenderer button;
    public int totalSoulsNeeded;
    public int soulPrice;
    public bool stayOn;
    public bool enemiesCanPress;
    private bool active = false;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(!active){
            if(col.gameObject.tag == "Player"){
                int souls = col.gameObject.GetComponent<PlayerScript>().GetSouls(totalSoulsNeeded, soulPrice);
                if(souls >= 0){
                    active = true;
                    button.color = new Color(0, 1, 0.125f);
                }
                else{
                    button.color = Color.red;
                }
            }
            if(col.gameObject.tag == "Enemy"){
                if(enemiesCanPress){
                    active = true;
                    button.color = new Color(0, 1, 0.125f);
                }
                else{
                    button.color = Color.red;
                }
            }
        }
    }
    public void OnTriggerExit2D(Collider2D col){
        if(!active){
            button.color = new Color(0, 0.392f, 0.125f);
        }
        else{
            if(!stayOn){
                active = false;
                button.color = new Color(0, 0.392f, 0.125f);
            }
        }
    }
    public bool GetState(){
        return active;
    }
}
