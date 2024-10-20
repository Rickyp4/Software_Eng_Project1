using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public string spawnerTag;
    public GameObject[] spawnedObject;
    public Transform[] spawnLocation;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == spawnerTag){
            if((spawnedObject.Length > 0)&&(spawnLocation.Length > 0)&&(spawnedObject.Length == spawnLocation.Length)){
                for(int i = 0; i < spawnedObject.Length; i++){
                    Instantiate(spawnedObject[i], spawnLocation[i].position, spawnLocation[i].rotation);
                }
            }
        }
    }

}
