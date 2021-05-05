using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour
{
    public static int points;
    public TextMeshProUGUI pointsText;

    void Start()
    {
        // if there is already a saved score then use that, otherwise points start at zero
        if (PlayerPrefs.HasKey("Points"))
        {
            points = PlayerPrefs.GetInt("Points");
        }
        else
        {
            points = 0;
        }
            
        pointsText.text = points.ToString() + " Points";
        pointsText = GameObject.Find("PointsText").GetComponent<TextMeshProUGUI>();                       
    }

    private void Update()
    {
        // probably an inefficient way to update the points text (but works)
        pointsText.text = points.ToString() + " Points";
    }

    // point added per match
    public void AddPoint()
    {
        points++;
        pointsText.text = points.ToString() + " Points";
    }

    // resetting score
    public void DeletePoints()
    {
        PlayerPrefs.DeleteKey("Points");
        points = 0;
        pointsText.text = points.ToString() + " Points";
    }

    // the points are saved to player prefs right before the scene changes (which destroys everything in previous seen)
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Points", points);
        PlayerPrefs.Save();
    }
}
