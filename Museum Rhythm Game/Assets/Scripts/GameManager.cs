using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public static bool startPlaying;
    public static GameManager instance;
    public Spawner tempoMarkers;
    public static bool endOfPiece;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        //when the game is booted up, the music and game should not start yet
        if (!startPlaying)
        {
            //if a button is pushed, start the beatscroller and music
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                tempoMarkers.hasStarted = true;

            }
 
        }
        //buggy area; the music doesn't even start
        else if (!theMusic.isPlaying && Cube.isMusicStarted)
        {
            tempoMarkers.hasStarted = false;
            Destroy(tempoMarkers);
        }

    }

    public bool NoteMissed()
    {
        Debug.Log("Missed Note");
        return true;
    }
}
