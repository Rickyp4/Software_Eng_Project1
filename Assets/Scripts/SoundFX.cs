using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public static SoundFX instance;
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
}
