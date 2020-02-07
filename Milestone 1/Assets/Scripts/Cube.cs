using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject marker, thisCube;
    public int speed = 4;

    void Update() {
        transform.position += 
        Time.deltaTime * transform.forward * speed;

        if (marker == null)
            Destroy(thisCube);

        float positionZ = 
        gameObject.transform.position.z;

        if (positionZ < -19) {
            Destroy(this.gameObject);
            GameManager.instance.NoteMissed();
        }
    }
}
