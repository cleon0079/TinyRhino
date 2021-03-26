using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rewards : MonoBehaviour
{
    public float maxScore;
    public TextMeshProUGUI rewards;
    // Start is called before the first frame update
    void Start()
    {
        rewards = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.scoreTime >= 0)
        {
            Random.Range(Score.scoreTime, maxScore);


        } 
    }
}
