using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleDoor : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    [SerializeField] private SpriteRenderer door;
    [SerializeField] private SpriteRenderer front;
    [SerializeField] private SpriteRenderer back;
    [SerializeField] private SpriteRenderer side1;
    [SerializeField] private SpriteRenderer side2;
    private bool open = false;

    public void Toggle(){
        if(!open){
            door.color = new Color(door.color.r, door.color.g, door.color.b, 0.25f);
            front.color = new Color(front.color.r, front.color.g, front.color.b, 0.25f);
            back.color = side1.color = side2.color = front.color;
            col.enabled = false;
            open = true;
        }
        else{
            door.color = new Color(door.color.r, door.color.g, door.color.b, 1);
            front.color = new Color(front.color.r, front.color.g, front.color.b, 1);
            back.color = side1.color = side2.color = front.color;
            col.enabled = true;
            open = false;
        }
    }
}
