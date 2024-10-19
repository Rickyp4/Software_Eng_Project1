using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public static SoundFX instance;
    public AudioClip[] stingE;
    public AudioClip[] stingA;
    public AudioClip[] stingB;
    public AudioClip[] stingG;
    public AudioClip[] stingD;
    public AudioClip[] stingC;
    [SerializeField] private AudioSource soundFXObj;
    private void Awake()
    {
        if (instance == null){
            instance = this;
        }
    }
    public void PlaySoundFX(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObj, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlayRandomSoundFX(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        int rand = Random.Range(0, audioClip.Length);
        AudioSource audioSource = Instantiate(soundFXObj, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip[rand];
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
    public void PlaySoundFX(AudioClip[] audioClip, Transform spawnTransform, float volume, int i)
    {
        AudioSource audioSource = Instantiate(soundFXObj, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip[i];
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
    public async void PlaySting(Transform spawnTransform, float volume, GameObject toBeDestroyed = null){
        AudioSource audioSource = Instantiate(soundFXObj, spawnTransform.position, Quaternion.identity);
        audioSource.transform.parent = spawnTransform;
        while(!(TimeKeeper.instance.startBeat && ((TimeKeeper.instance.beat == 2)||(TimeKeeper.instance.beat == 3)))){
            await Task.Yield();
        }
        int rand;
        switch(TimeKeeper.instance.chord){
            case(1):
                rand = Random.Range(0, stingE.Length);
                audioSource.clip = stingE[rand];
            break;
            case(4):
                rand = Random.Range(0, stingA.Length);
                audioSource.clip = stingA[rand];
            break;
            case(5):
                rand = Random.Range(0, stingB.Length);
                audioSource.clip = stingB[rand];
            break;
            case(3):
                rand = Random.Range(0, stingG.Length);
                audioSource.clip = stingG[rand];
            break;
            case(7):
                rand = Random.Range(0, stingD.Length);
                audioSource.clip = stingD[rand];
            break;
            case(6):
                rand = Random.Range(0, stingC.Length);
                audioSource.clip = stingC[rand];
            break;
            default:
            Destroy(audioSource.gameObject);
            break;
        }
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
        if(toBeDestroyed != null){
            Destroy(toBeDestroyed, clipLength);
        }
    }
}
