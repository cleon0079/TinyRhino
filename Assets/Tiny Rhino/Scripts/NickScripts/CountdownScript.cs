using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static float timeLeft;
    public float timeLostPerSecond;
    Scene scene;

    void Start()
    {
        timeLostPerSecond = 1f;

        scene = SceneManager.GetActiveScene();

        // countdown timeframe for each level
        if (scene.buildIndex == 1)
        {           
            timeLeft = 60f;
        }
        else if (scene.buildIndex == 2)
        {
            timeLeft = 30f;
        }
        else if (scene.buildIndex == 3)
        {
            timeLeft = 10f;
        }
    }

    void Update()
    {
        // countdown is based on real time
        timeLeft -= timeLostPerSecond * Time.deltaTime;
        // score is displayed as text
        scoreText.text = timeLeft.ToString("0");

        // if countdown reaches 0, the 'Results' scene is loaded
        if (CountdownScript.timeLeft <= 0)
        {
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
    }
}
