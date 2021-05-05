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

    void Start()
    {
        // 60 seconds countdown
        timeLeft = 60f;
        timeLostPerSecond = 1f;
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
            SceneManager.LoadScene("Results");
        }
    }
}
