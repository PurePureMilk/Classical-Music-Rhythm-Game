using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    public LayerMask bothLayers;
    private Vector3 previousPos;
    public GameManager manager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //saber controls
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if(Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                Destroy(hit.transform.gameObject);
                GameManager.instance.NoteHit();
                if (Cube.isMusicStarted == false)
                {
                    Cube.isMusicStarted = true;
                    GameManager.instance.theMusic.Play();

                }
                
            }
        }

        
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, bothLayers))
        {
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                Destroy(hit.transform.gameObject);
                GameManager.instance.NoteHit();
                if (hit.transform.tag == "Summer Painting")
                {
                    string paintingName = hit.transform.name;
                    GameManager.instance.paintingsCollected.Add(paintingName);
                }
                Debug.Log(hit.transform.tag);


            }
        }
        
        previousPos = transform.position;
        

    }
}

