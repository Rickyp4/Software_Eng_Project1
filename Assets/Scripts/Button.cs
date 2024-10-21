using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Timeline;

public class Button : MonoBehaviour
{
    public SpriteRenderer button;
    public ToggleDoor toggleDoor;
    public ToggleLaser toggleLaser;
    public int totalSoulsNeeded;
    public int soulPrice;
    public bool stayOn;
    public bool enemiesCanPress;
    [SerializeField] private GameObject soulButton;
    private bool active = false;
    public void Awake(){
        if(totalSoulsNeeded > 0){
            soulButton.SetActive(true);
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(!active){
            if(col.gameObject.tag == "Player"){
                int souls = col.gameObject.GetComponent<PlayerScript>().GetSouls(totalSoulsNeeded, soulPrice);
                if(souls >= 0){
                    active = true;
                    Activate();
                    button.color = new Color(0, 1, 0.125f);
                }
                else{
                    button.color = Color.red;
                }
            }
            if(col.gameObject.tag == "Enemy"){
                if(enemiesCanPress){
                    active = true;
                    Activate();
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
                Deactivate();
                button.color = new Color(0, 0.392f, 0.125f);
            }
        }
    }
    public bool GetState(){
        return active;
    }
    private void Activate(){
        if(toggleDoor != null){
            toggleDoor.Toggle(stayOn);
        }
        if(toggleLaser != null){
            toggleLaser.Toggle();
        }
    }
    private void Deactivate(){
        if(toggleDoor != null){
            toggleDoor.Toggle();
        }
        if(toggleLaser != null){
            toggleLaser.Toggle();
        }
    }
}
