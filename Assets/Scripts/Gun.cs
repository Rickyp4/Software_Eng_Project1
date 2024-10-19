using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun : MonoBehaviour
{
    public GameObject Bullet;
    public Transform firePoint;
    public float fireForce;
    public int maxAmmo = 6;
    public int curAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    [SerializeField] private AudioClip[] gunshots;

    private void Awake(){
        curAmmo = maxAmmo;
    }
    public void Update(){
        if(isReloading){
            return;
        }
        if(curAmmo <= 0){
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetMouseButtonDown(0) && !PauseMenu.isPaused){
            Fire();
        }
    }
    public void Fire(){
        curAmmo--;
        GameObject projectile = Instantiate(Bullet, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        switch(TimeKeeper.instance.chord){
            case(1):
            SoundFX.instance.PlaySoundFX(gunshots, firePoint, 1f, 0);
            break;
            case(4):
            SoundFX.instance.PlaySoundFX(gunshots, firePoint, 1f, 1);
            break;
            case(5):
            SoundFX.instance.PlaySoundFX(gunshots, firePoint, 1f, 2);
            break;
            case(3):
            SoundFX.instance.PlaySoundFX(gunshots, firePoint, 1f, 3);
            break;
            case(7):
            SoundFX.instance.PlaySoundFX(gunshots, firePoint, 1f, 4);
            break;
            case(6):
            SoundFX.instance.PlaySoundFX(gunshots, firePoint, 1f, 5);
            break;
        }
    }
    private IEnumerator Reload(){
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        curAmmo = maxAmmo;
        isReloading = false;
    }
}
