using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //mouse controls
        //https://www.youtube.com/watch?v=0sFrDJKwsdM << can use to change scenes

        if (Input.GetMouseButtonDown(0))
        {


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitMouse;
            if (Physics.Raycast(ray, out hitMouse))
            {

                if (hitMouse.transform.tag == "Summer Painting" ||
                    hitMouse.transform.tag == "Blue" ||
                    hitMouse.transform.tag == "Green")
                {
                    Destroy(hitMouse.transform.gameObject);
                    GameManager.instance.NoteHit();
                    if (hitMouse.transform.tag == "Summer Painting")
                    {
                        string paintingName = hitMouse.transform.name;
                        GameManager.instance.paintingsCollected.Add(paintingName);
                    }
                    Debug.Log(hitMouse.transform.tag);


                    if (Cube.isMusicStarted == false)
                    {
                        Cube.isMusicStarted = true;
                        GameManager.instance.theMusic.Play();

                    }
                }
            }
        }
    }
}
