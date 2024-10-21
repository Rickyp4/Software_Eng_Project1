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
    public AudioClip[] FillEE;
    public AudioClip[] FillEG;
    public AudioClip[] FillEA;
    public AudioClip[] FillEB;
    public AudioClip[] FillEC;
    public AudioClip[] FillGG;
    public AudioClip[] FillGA;
    public AudioClip[] FillGD;
    public AudioClip[] FillAE;
    public AudioClip[] FillAA;
    public AudioClip[] FillBE;
    public AudioClip[] FillBA;
    public AudioClip[] FillBC;
    public AudioClip[] FillCB;
    public AudioClip[] FillDE;
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
    public GameObject PlaySoundFX(AudioClip audioClip, Transform spawnTransform, float volume, bool returnSource)
    {
        AudioSource audioSource = Instantiate(soundFXObj, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
        return audioSource.gameObject;
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
    public void PlaySoundFX(AudioClip[] audioClip, Transform spawnTransform, float volume, int i, bool isAttached = false)
    {
        AudioSource audioSource = Instantiate(soundFXObj, spawnTransform.position, Quaternion.identity);
        if(isAttached){
            audioSource.transform.parent = spawnTransform;
        }
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
    public async void PlayFill(Transform spawnTransform, float volume, GameObject toBeDestroyed = null){
        AudioSource audioSource = Instantiate(soundFXObj, spawnTransform.position, Quaternion.identity);
        audioSource.transform.parent = spawnTransform;
        while(!TimeKeeper.instance.startBar){
            await Task.Yield();
        }
        int rand;
        switch(TimeKeeper.instance.chord, TimeKeeper.instance.nextChord){
            case(1, 1):
                rand = Random.Range(0, FillEE.Length);
                audioSource.clip = FillEE[rand];
                break;
            case(1, 3):
                rand = Random.Range(0, FillEG.Length);
                audioSource.clip = FillEG[rand];
                break;
            case(1, 4):
                rand = Random.Range(0, FillEA.Length);
                audioSource.clip = FillEA[rand];
                break;
            case(1, 5):
                rand = Random.Range(0, FillEB.Length);
                audioSource.clip = FillEB[rand];
                break;
            case(1, 6):
                rand = Random.Range(0, FillEC.Length);
                audioSource.clip = FillEC[rand];
                break;
            case(3, 3):
                rand = Random.Range(0, FillGG.Length);
                audioSource.clip = FillGG[rand];
                break;
            case(3, 4):
                rand = Random.Range(0, FillGA.Length);
                audioSource.clip = FillGA[rand];
                break;
            case(3, 7):
                rand = Random.Range(0, FillGD.Length);
                audioSource.clip = FillGD[rand];
                break;
            case(4, 1):
                rand = Random.Range(0, FillAE.Length);
                audioSource.clip = FillAE[rand];
                break;
            case(4, 4):
                rand = Random.Range(0, FillAA.Length);
                audioSource.clip = FillAA[rand];
                break;
            case(5, 1):
                rand = Random.Range(0, FillBE.Length);
                audioSource.clip = FillBE[rand];
                break;
            case(5, 4):
                rand = Random.Range(0, FillBA.Length);
                audioSource.clip = FillBA[rand];
                break;
            case(5, 6):
                rand = Random.Range(0, FillBC.Length);
                audioSource.clip = FillBC[rand];
                break;
            case(6, 5):
                rand = Random.Range(0, FillCB.Length);
                audioSource.clip = FillCB[rand];
                break;
            case(7, 1):
                rand = Random.Range(0, FillDE.Length);
                audioSource.clip = FillDE[rand];
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
