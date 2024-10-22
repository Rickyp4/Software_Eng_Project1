using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnInvis : MonoBehaviour
{
    public bool turnInvis;
    private GameObject[] objects;
    private GameObject[] objects2;
    void Start()
    {
        if(turnInvis){
            objects = GameObject.FindGameObjectsWithTag("Invis");
            objects2 = GameObject.FindGameObjectsWithTag("Direct");
            if(objects.Length > 0){
                for(int i = 0; i < objects.Length; i++){
                    objects[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            if(objects2.Length > 0){
                for(int i = 0; i < objects2.Length; i++){
                    objects2[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
    }
}
