using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFlicker : MonoBehaviour
{
    public SpriteRenderer sr;
    public float flickerRate;
    private float oppacity;
    private bool brighten = true;
    void Update()
    {
        if(brighten){
            oppacity += Time.deltaTime*flickerRate;
            if(oppacity >= 1){
                brighten = false;
            }
        }
        if(!brighten){
            oppacity -= Time.deltaTime*flickerRate;
            if(oppacity <= 0){
                brighten = true;
            }
        }
        sr.color = new Color(0, 1, 1, oppacity);
    }
}
