using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    private void Update()
    {
        // press any key to load the main menu scene
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
