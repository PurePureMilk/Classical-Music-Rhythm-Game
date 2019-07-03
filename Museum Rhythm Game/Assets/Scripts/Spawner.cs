using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public float beat;
    private float timer;

    public bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {

        }
        else
        {
            if (timer > beat)
            {
                GameObject cube = Instantiate(cubes[Random.Range(0, 7)], points[Random.Range(0, 4)]);
                cube.transform.localPosition = Vector3.zero;
                cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
                timer -= beat;
            }
            timer += Time.deltaTime;
        }

        if (!GameManager.instance.theMusic.isPlaying && Cube.isMusicStarted)
        {
            GameManager.instance.tempoMarkers.hasStarted = false;
            Destroy(GameManager.instance.tempoMarkers);
        }

    }
}
