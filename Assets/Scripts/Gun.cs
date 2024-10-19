using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet;
    public Transform firePoint;
    public float fireForce;
    [SerializeField] private AudioClip[] gunshots;

    public void Fire(){
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
}
