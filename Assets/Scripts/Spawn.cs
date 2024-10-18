using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public string spawnerTag;
    public GameObject spawnedObject;
    public Transform spawnLocation;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == spawnerTag){
            Instantiate(spawnedObject, spawnLocation.position, spawnLocation.rotation);
        }
    }

}
