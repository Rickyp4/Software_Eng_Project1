using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    public static TimeKeeper instance;
    public float tempo;
    public int beat;
    public int bar;
    public int chord;
    public int nextChord;
    public bool flat;
    public bool startBeat;
    public bool startBar;
    public AudioSource music;
    private float time = 0;
    private int totalBeat;
    private int prevBeat;
    private int prevBar;
    private bool musicIsPaused = false;
    private int[] chords = 
    {
    1, 1, 1, 1,
    4, 4, 1, 1,
    5, 4, 1, 5,
    1, 4, 1, 1,
    4, 4, 1, 1,
    5, 4, 1, 5,
    1, 3, 7, 1,
    3, 3, 4, 1,
    6, 5, 6, 5
    };
    private bool[] flats = 
    {
    false, false, false, false,
    false, false, false, false,
    false, false, false, false,
    false, false, false, false,
    false, false, false, false,
    false, false, false, false,
    false, true, true, false,
    true, true, false, false,
    true, false, true, false
    };
    private void Awake()
    {
        if (instance == null){
            instance = this;
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        totalBeat = (int)(time*tempo/60);
        bar = (totalBeat/4)%36 +1;
        beat = totalBeat%4+1;
        chord = chords[bar-1];
        if(bar < 36){
            nextChord = chords[bar];
        }
        else{
            nextChord = chords[0];
        }
        flat = flats[bar-1];
        if(PauseMenu.isPaused){
            if(!musicIsPaused){
                music.Pause();
                musicIsPaused = true;
            }
        }
        if(!PauseMenu.isPaused){
            if(musicIsPaused){
                music.UnPause();
                musicIsPaused = false;
            }
        }
    }
    void FixedUpdate()
    {
        if (prevBeat != beat){
            startBeat = true;
        }
        else{
            startBeat = false;
        }
        prevBeat = beat;
        if (prevBar != bar){
            if((bar == 1)&&(beat ==  1)){
                music.Play();
            } 
            startBar = true;
        }
        else{
            startBar = false;
        }
        prevBar = bar;
    }
}
