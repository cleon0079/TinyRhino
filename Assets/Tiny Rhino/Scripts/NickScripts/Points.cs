using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public static int highscore;
    public static int score;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI scoreText;

    void Start()
    {     
        // highscore setup
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscore = PlayerPrefs.GetInt("Highscore");
        } 
        else
        {
            highscore = 0;
        }

        // score setup
        score = 0;
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        highscoreText.text = highscore.ToString();
    }

    private void Update()
    {
        // inefficient way to update the scores text
        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();
    }

    // point added per individual food destroyed
    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString();
    }

    // the points are saved to player prefs right before the scene changes (which destroys everything in previous seen)
    private void OnDestroy()
    {
        // if score is higher than the highscore the score becomes the new highscore
        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }           
    }
}
