using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        // game isn't paused initially and pause menu is invisible
        pauseMenu.SetActive(false);
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if escape button is pressed
        // if not paused then pause the game
        // if paused then resume the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("escape is pressed");

            if (paused == false)
            {
                Pause();
            }
            else if (paused == true)
            {
                Resume();
            }
        }
    }

    // runtime is frozen and pause menu visible
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        paused = true;
    }

    // runtime is normal and pause menu is invisible
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        paused = false;
    }
}
