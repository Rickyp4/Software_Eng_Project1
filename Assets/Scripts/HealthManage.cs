using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManage : MonoBehaviour
{
    public static HealthManage instance;
    public Image healthbar;
    public void Awake(){
        if (instance == null){
            instance = this;
        }
    }
    public void HealthBarUpdate(int hp){
        healthbar.fillAmount = hp / 3f;
    }
}
