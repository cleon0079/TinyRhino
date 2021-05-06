using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetPoints : MonoBehaviour
{
    public int highscore;
    public TextMeshProUGUI highscoreText;

    void Start()
    {
        highscoreText = GameObject.Find("Highscore").GetComponent<TextMeshProUGUI>();

        // set highscore if it exists
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscore = PlayerPrefs.GetInt("Highscore");                     
        }
        else
        {
            highscore = 0;
        }

        highscoreText.text = highscore.ToString();
    }

    // reset highscore
    public void ResetHighscore()
    {
        PlayerPrefs.DeleteKey("Highscore");
        highscore = 0;
        highscoreText.text = highscore.ToString();
    }
}
