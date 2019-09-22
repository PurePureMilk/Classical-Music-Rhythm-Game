using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSelectionScreen : MonoBehaviour
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
                Debug.Log(hit.transform.name);

                //Select Love Stage
                if (hit.transform.name == "Heart")
                {
                    SceneManager.LoadScene("Romantic Beach");
                }

                //Select Atrium Stage
                if (hit.transform.name == "Atrium")
                {
                    SceneManager.LoadScene("Atrium");
                }

                //Select Viola Stage
                if (hit.transform.name == "Viola")
                {
                    SceneManager.LoadScene("Viola Practice");
                }

            }
        }

        
    }
}
