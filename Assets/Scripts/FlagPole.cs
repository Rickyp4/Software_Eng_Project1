using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagPole : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            SceneManager.LoadScene("GameOver");
        }
    }
}
