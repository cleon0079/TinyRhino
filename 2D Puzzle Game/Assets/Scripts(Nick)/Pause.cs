using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool paused;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        paused = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == true)
            {
                ResumeGame();
            }
            else if (paused == false)
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        paused = false;
        pauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        paused = true;
        pauseMenu.SetActive(true);
    }
}
