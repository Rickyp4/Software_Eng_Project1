using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    [SerializeField] private AudioMixer mixer;
    void Start()
    {
        pauseMenu.SetActive(false);
        mixer.SetFloat("MusicVolume", Mathf.Log10(0.4f)*20);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    
    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void mainMenu(){
        ResumeGame();
        SceneManager.LoadScene("Menu");
    }
    public void MusicVolume(float level){
        mixer.SetFloat("MusicVolume", Mathf.Log10(level)*20);
    }
    public void SFXVolume(float level){
        mixer.SetFloat("SoundFXVolume", Mathf.Log10(level)*20);
    }
}
