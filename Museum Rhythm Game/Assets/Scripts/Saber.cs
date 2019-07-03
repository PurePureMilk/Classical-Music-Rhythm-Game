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
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if(Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                Destroy(hit.transform.gameObject);

                /*when you hit, you start the music, but you also need when you miss
                if (manager.startPlaying == false)
                {
                    manager.theMusic.Play();
                    manager.startPlaying = true;

                }
                */
            }
        }

        
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, bothLayers))
        {
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                Destroy(hit.transform.gameObject);
            }
        }
        
        previousPos = transform.position;
    }
}
