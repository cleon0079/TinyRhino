using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static float scoreTime;
    public float scorePerSecond;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        scoreTime = 180.0f;
        scorePerSecond = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTime -= scorePerSecond * Time.deltaTime;
        scoreText.text = scoreTime.ToString("0") + " seconds left";

        if (scoreTime <= 0)
        {
            SceneManager.LoadScene("Fail");
        }
        else
        {

        }    
    }
}
