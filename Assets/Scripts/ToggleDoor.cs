using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ToggleDoor : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    [SerializeField] private SpriteRenderer door;
    [SerializeField] private SpriteRenderer front;
    [SerializeField] private SpriteRenderer back;
    [SerializeField] private SpriteRenderer side1;
    [SerializeField] private SpriteRenderer side2;
    [SerializeField] private SpriteRenderer soul;
    [SerializeField] private GameObject soulObject;
    private bool open = false;

    public void Toggle(bool playFill = false){
        if(!open){
            if(playFill){
                SoundFX.instance.PlayFill(gameObject.transform, 1, soulObject);
                Open();
            }
            else{
                door.color = new Color(door.color.r, door.color.g, door.color.b, 0.25f);
                front.color = new Color(front.color.r, front.color.g, front.color.b, 0.25f);
                back.color = side1.color = side2.color = front.color;
                col.enabled = false;
                open = true;
            }
        }
        else{
            door.color = new Color(door.color.r, door.color.g, door.color.b, 1);
            front.color = new Color(front.color.r, front.color.g, front.color.b, 1);
            back.color = side1.color = side2.color = front.color;
            col.enabled = true;
            open = false;
        }
    }
    public async void Open(){
        soul.enabled = true;
        while(!TimeKeeper.instance.startBar){
            await Task.Yield();
        }
        door.color = new Color(door.color.r, door.color.g, door.color.b, 0.25f);
        front.color = new Color(front.color.r, front.color.g, front.color.b, 0.25f);
        back.color = side1.color = side2.color = front.color;
        col.enabled = false;
        open = true;
    }
}
