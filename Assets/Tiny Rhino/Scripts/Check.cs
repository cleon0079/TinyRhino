using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    CreateFood food;
    
    // Start is called before the first frame update
    void Start()
    {
        food = GameObject.Find("CreatBox").GetComponent<CreateFood>();
        if (transform.childCount == 0)
        {
            GameObject sonFoods = food.CreateFoods();
            sonFoods.transform.parent = transform;
            sonFoods.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
