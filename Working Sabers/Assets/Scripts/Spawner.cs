using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public float beat;
    private float timer;
    private int numOfCubeReleased = 0;
    private int cubeToRelease = 2;

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
                GameObject cube = null;
                if (numOfCubeReleased == 3 || numOfCubeReleased == 6)
                {
                    cube = Instantiate(cubes[cubeToRelease], points[Random.Range(0, 4)]);
                    cubeToRelease++;
                }
                else
                {
                    cube = Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0, 4)]);
                }
                numOfCubeReleased++;
                cube.transform.localPosition = Vector3.zero;
                cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
                timer -= beat;
            }
            timer += Time.deltaTime;
        }



    }
}
