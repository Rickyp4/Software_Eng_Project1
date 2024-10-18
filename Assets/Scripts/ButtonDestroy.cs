using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDestroy : MonoBehaviour
{
    public GameObject obj;
    public void OnTriggerEnter2D(Collider2D col)
    {
        bool state = gameObject.GetComponent<Button>().GetState();
        if(state){
            Destroy(obj);
        }
    }
}
