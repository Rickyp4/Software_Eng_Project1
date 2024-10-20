using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    public string triggerTag;
    public ToggleDoor toggleScript;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(toggleScript != null){
            if(col.gameObject.tag == triggerTag){
                toggleScript.Toggle();
            }
        }
    }
}
