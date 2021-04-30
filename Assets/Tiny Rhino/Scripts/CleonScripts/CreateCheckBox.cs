using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCheckBox : MonoBehaviour
{
    CreatePlate food;
    
    // Start is called before the first frame update
    void Start()
    {
        food = CreatePlate.instance;// GameObject.FindObjectOfType<CreatePlate>();//.GetComponent<CreatePlate>();
        if(food == null)
        {
            Debug.LogError(name +": CreatePlate does not exist in the scene for CreateCheckBox");
        }
        if (transform.childCount == 0)
        {
            GameObject sonFoods = food.CreateFoods();
            sonFoods.transform.parent = transform;
            sonFoods.transform.position = transform.position;
        }
    }
}
