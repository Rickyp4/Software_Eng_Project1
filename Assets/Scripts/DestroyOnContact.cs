using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public string triggerTag;
    public bool destroyOnTrigger;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == triggerTag){
            if(destroyOnTrigger){
                Destroy(gameObject);
            }
        }
    }
}
