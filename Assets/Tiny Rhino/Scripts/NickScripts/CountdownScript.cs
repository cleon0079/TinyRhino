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

    // Start is called before the first frame update
    void Start()
    {   
        // 60 seconds countdown
        timeLeft = 60f;
        timeLostPerSecond = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        // countdown is based on real time
        timeLeft -= timeLostPerSecond * Time.deltaTime;
        // score is displayed
        scoreText.text = timeLeft.ToString("0");

        // if countdown reaches 0, the 'GameOver' scene is loaded
        if (timeLeft <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
