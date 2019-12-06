using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.name);

                //Select Love Stage
                if (hit.transform.name == "Love Ball")
                {
                    SceneManager.LoadScene("Love");
                }

                //Select Atrium Stage
                if (hit.transform.name == "Orchestra Ball")
                {
                    SceneManager.LoadScene("Orchestra");
                }

                //Select Viola Stage
                if (hit.transform.name == "Viola Ball")
                {
                    SceneManager.LoadScene("Viola");
                }

                if (hit.transform.name == "Selection Ball")
                {
                    SceneManager.LoadScene("Selection");

                    /*Resets the state of the game*/
                    GameManager.instance.startPlaying = false;
                    GameManager.instance.tempoMarkers.hasStarted = false;
                    GameManager.instance.theMusic.Stop();

                }

                if (hit.transform.tag == "Special Painting" ||
                    hit.transform.tag == "Blue" ||
                    hit.transform.tag == "Red")
                {
                    Destroy(hit.transform.gameObject);
                    GameManager.instance.NoteHit();
                    if (hit.transform.tag == "Special Painting")
                    {
                        string paintingName = hit.transform.name;
                        Debug.Log(hit.transform.name);
                        GameManager.instance.paintingsCollected.Add(paintingName);
                    }

                    /*
                    if (Cube.isMusicStarted == false)
                    {
                        Cube.isMusicStarted = true;
                        GameManager.instance.theMusic.Play();

                    }
                    */
                }

            }
        }


    }
}
