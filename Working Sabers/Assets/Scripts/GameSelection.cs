using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSelection : MonoBehaviour
{
    public void Love()
    {
        SceneManager.LoadScene("Love");
    }

    public void Orchestra()
    {
        SceneManager.LoadScene("Orchestra");
    }

    public void Viola()
    {
        SceneManager.LoadScene("Viola");
    }
}
