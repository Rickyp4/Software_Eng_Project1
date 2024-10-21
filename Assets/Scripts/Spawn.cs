using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public string spawnerTag;
    public GameObject[] spawnedObject;
    public int[] enemyHP;
    public int[] enemySoulValue;
    public Transform[] spawnLocation;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == spawnerTag){
            if((spawnedObject.Length > 0)&&(spawnLocation.Length > 0)&&(spawnedObject.Length == spawnLocation.Length)){
                for(int i = 0; i < spawnedObject.Length; i++){
                    GameObject  obj = Instantiate(spawnedObject[i], spawnLocation[i].position, spawnLocation[i].rotation);
                    if(enemyHP.Length > i){
                        obj.GetComponent<EnemyAI>().hp = enemyHP[i];
                    }
                    if(enemySoulValue.Length > i){
                        EnemyAI script = obj.GetComponent<EnemyAI>();
                        if(script.soulValue > 0){
                            script.soulValue = enemySoulValue[i];
                        }
                        else{
                            Debug.Log("Don't use Soulless variant");
                        }
                    }
                }
            }
        }
    }

}
