using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFood : MonoBehaviour
{
    CreatePlate food;

    // Start is called before the first frame update
    void Start()
    {
        food = GameObject.FindObjectOfType<CreatePlate>().GetComponent<CreatePlate>();
        if (transform.childCount == 0)
        {
            GameObject sonFoods = food.CreateCheckBox();
            sonFoods.transform.parent = transform;
            sonFoods.transform.position = transform.position;
        }
    }
}
