using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLaser : MonoBehaviour
{
    public bool isActive;
    public SpriteRenderer sr;
    public Collider2D col;
    public void Start(){
        sr.enabled = isActive;
        col.enabled = isActive;
    }
    public void Toggle(){
        isActive = !isActive;
        sr.enabled = isActive;
        col.enabled = isActive;
    }
}
