using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    [SerializeField] private AudioClip[] emptyChamber;
    [SerializeField] private AudioClip[] reloading;
    [SerializeField] private SpriteRenderer[] ammoSprite;

    private void Awake(){
        curAmmo = maxAmmo;
    }
    public void Update(){
        if(isReloading){
            if(Input.GetMouseButtonDown(0) && !PauseMenu.isPaused){
                switch(TimeKeeper.instance.chord){
                    case(1):
                    SoundFX.instance.PlaySoundFX(emptyChamber, firePoint, 0.7f, 0);
                    break;
                    case(4):
                    SoundFX.instance.PlaySoundFX(emptyChamber, firePoint, 0.7f, 1);
                    break;
                    case(5):
                    SoundFX.instance.PlaySoundFX(emptyChamber, firePoint, 0.7f, 2);
                    break;
                    case(3):
                    SoundFX.instance.PlaySoundFX(emptyChamber, firePoint, 0.7f, 3);
                    break;
                    case(7):
                    SoundFX.instance.PlaySoundFX(emptyChamber, firePoint, 0.7f, 4);
                    break;
                    case(6):
                    SoundFX.instance.PlaySoundFX(emptyChamber, firePoint, 0.7f, 5);
                    break;
                }
            }
            return;
        }
        if(curAmmo <= 0){
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetKeyDown(KeyCode.R) && !PauseMenu.isPaused){
            foreach (SpriteRenderer sr in ammoSprite){
                sr.enabled = false;
            }
            StartCoroutine(Reload());
            return;
        }
        if(Input.GetMouseButtonDown(0) && !PauseMenu.isPaused){
            Fire();
        }
    }
    public void Fire(){
        curAmmo--;
        ammoSprite[curAmmo].enabled = false;
        GameObject projectile = Instantiate(Bullet, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
        switch(TimeKeeper.instance.chord){
            case(1):
            SoundFX.instance.PlaySoundFX(gunshots, firePoint, 0.7f, 0);
            break;
            case(4):
            SoundFX.instance.PlaySoundFX(gunshots, firePoint, 0.7f, 1);
            break;
            case(5):
            SoundFX.instance.PlaySoundFX(gunshots, firePoint, 0.7f, 2);
            break;
            case(3):
            SoundFX.instance.PlaySoundFX(gunshots, firePoint, 0.7f, 3);
            break;
            case(7):
            SoundFX.instance.PlaySoundFX(gunshots, firePoint, 0.7f, 4);
            break;
            case(6):
            SoundFX.instance.PlaySoundFX(gunshots, firePoint, 0.7f, 5);
            break;
        }
    }
    private IEnumerator Reload(){
        isReloading = true;
        ReloadSound();
        yield return new WaitForSeconds(reloadTime);
        curAmmo = maxAmmo;
        foreach (SpriteRenderer sr in ammoSprite){
            sr.enabled = true;
        }
        isReloading = false;
    }
    private async void ReloadSound(){
        while(!TimeKeeper.instance.startBeat){
            await Task.Yield();
        }
        switch(TimeKeeper.instance.chord){
            case(1):
            SoundFX.instance.PlaySoundFX(reloading, firePoint, 0.7f, 0, true);
            break;
            case(4):
            SoundFX.instance.PlaySoundFX(reloading, firePoint, 0.7f, 1, true);
            break;
            case(5):
            SoundFX.instance.PlaySoundFX(reloading, firePoint, 0.7f, 2, true);
            break;
            case(3):
            SoundFX.instance.PlaySoundFX(reloading, firePoint, 0.7f, 3, true);
            break;
            case(7):
            SoundFX.instance.PlaySoundFX(reloading, firePoint, 0.7f, 4, true);
            break;
            case(6):
            SoundFX.instance.PlaySoundFX(reloading, firePoint, 0.7f, 5, true);
            break;
        }
    }
}
