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
    public bool flat;
    public bool start;
    public AudioSource music;
    private float time = 0;
    private int totalBeat;
    private int prevBeat;
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
        flat = flats[bar-1];
    }
    void FixedUpdate()
    {
        if (prevBeat != beat){
            if((bar == 1)&&(beat ==  1)){
                music.Play();
            }
            start = true;
        }
        else{
            start = false;
        }
        prevBeat = beat;
    }
}
