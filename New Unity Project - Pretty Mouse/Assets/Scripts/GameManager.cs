using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.


public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public static GameManager instance;
    public Spawner tempoMarkers;
    //public static bool endOfPiece;
    //if it not static then every single note object has control the audio

    public float missedHits;
    public float hits;

    public TextMeshProUGUI nameOfPaintingsCollectedText;
    //public GameObject resultsScreen;

    public ArrayList paintingsCollected = new ArrayList();

    public GameObject Painting1;
    public GameObject Painting2;

    public Sprite SP1;
    public Sprite SP2;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        theMusic.Stop();
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
                theMusic.Play();
            }

        }
        else if (!theMusic.isPlaying /*&& Cube.isMusicStarted*/)
        {
            //Stops the spawner from spitting out stuff
            tempoMarkers.hasStarted = false;
            /*Display Paintings*/
            //nameOfPaintingsCollectedText.text = "Collected:";
            foreach (string g in paintingsCollected)
            {
                Debug.Log("Paintings Collected: " + g);
                //nameOfPaintingsCollectedText.text += " " + g;
            }

            Debug.Log("Capacity: " + paintingsCollected.Capacity);
            Debug.Log("Count: " + paintingsCollected.Count);

            //if (!resultsScreen.activeInHierarchy)
            //resultsScreen.SetActive(true);
            if (paintingsCollected.Contains("1"))
            {
                Painting1.gameObject.GetComponent<SpriteRenderer>().sprite = SP1;

            }
            if (paintingsCollected.Contains("2"))
            {
                Painting2.gameObject.GetComponent<SpriteRenderer>().sprite = SP2;
            }
        } 

    }

    public bool NoteMissed()
    {
        Debug.Log("Missed Note");
        missedHits++;
        return true;
    }

    public bool NoteHit()
    {
        Debug.Log("Note Hit");
        hits++;
        return true;
    }
}
