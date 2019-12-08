using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject marker;
    public GameObject thisCube;
    public int speed = 2;
    //public static bool isMusicStarted = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * speed;

        if (marker == null)
        {
            Destroy(thisCube);

        }

        float positionZ = gameObject.transform.position.z;


        /*
        if (positionZ > 16 && !isMusicStarted)
        {
            isMusicStarted = true;
            GameManager.instance.theMusic.Play();
            Debug.Log(isMusicStarted);

        }
        */

        //Debug.Log(positionZ);

        if (positionZ < -19)
        {
            Destroy(this.gameObject);
            GameManager.instance.NoteMissed();
        }


    }
}
