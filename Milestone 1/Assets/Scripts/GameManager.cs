using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add the TextMesh Pro namespace to access the various functions.


public class GameManager : MonoBehaviour
{
    public bool isVR;
    public AudioSource theMusic;
    public bool startPlaying;
    public static GameManager instance;
    public Spawner tempoMarkers;

    private float missedHits;
    private float hits;

    //public TextMeshProUGUI nameOfPaintingsCollectedText;
    //public GameObject resultsScreen;

    public ArrayList paintingsCollected = new ArrayList();

    public GameObject Painting1;
    public GameObject Painting2;

    public Sprite SP1;
    public Sprite SP2;
    public TextMeshProUGUI paintingDescription;
    public string stage;
    public GameObject Camera;
    public GameObject VRCamera;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        theMusic.Stop();
        if (!isVR) {
            Camera.SetActive(true);
            VRCamera.SetActive(false);
        } else {
            Camera.SetActive(false);
            VRCamera.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isVR)
        {
            Camera.SetActive(true);
            VRCamera.SetActive(false);
        }
        else
        {
            Camera.SetActive(false);
            VRCamera.SetActive(true);
        }
        
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
                
                if (stage.Equals("Love")) {
                    paintingDescription.text = "How music and art can be depicted together to express " +
                    "“love” can be through a painting called “The reconciliation of Oberon and Titania”. " +
                    "This depicts a scene in the famous play 'A Midsummer Night's Dream' where the main " +
                    "message of love is “The course of love never did run smooth”. The painting depicts " +
                    "numerous fairies playing instruments to soothes the sleeping lovers. The most notable " +
                    "repertoire is written by Felix Mendelsohn called “Wedding March”.";
                } else if (stage.Equals("Orchestra")) {
                    paintingDescription.text = "How music and art can be depicted together in the setting of " +
                    "an “orchestra” can through a painting called “The Great Concerto”. This painting " +
                    "depicts a scene where a piano soloist is playing directly in front of the audience. " +
                    "How the painter the depicts the pianist as virtuosic is by painting the lines of the " +
                    "pianist’s arms which echoes the lines of the piano. The strokes are rapid strokes " +
                    "suggesting flourishing virtuosity in the pianist’s part. A repertoire I chose for " +
                    "this painting is Piano Concerto in A minor, Op. 16 because of the “flourishing” introduction of the concerto.";
                } else if(stage.Equals("Viola")) {
                    paintingDescription.text = "How music and art can be depicted together in the embodiment of " +
                    "what it’s like to be a violist through painting depicting violins, violas, and cellos which " +
                    "makes up a standard string quartet. The viola and violists have a history of being " +
                    "neglected and suffered a subordinate position with respect to the violin by historians " + 
                    "and musicians where the viola part was assigned to violinists who had failed to achieve brilliance.";
                }
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
