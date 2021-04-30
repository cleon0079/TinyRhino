using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFood : MonoBehaviour
{
    CreatePlate food;
    public List<GameObject> foods = new List<GameObject>();
    public List<GameObject> checkBoxs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        food = GameObject.Find("CreatBox").GetComponent<CreatePlate>();
        if (transform.childCount == 0)
        {
            GameObject sonFoods = food.CreateCheckBox();
            sonFoods.transform.parent = transform;
            sonFoods.transform.position = transform.position;
        }
    }
	
    public GameObject CreateFoods()
    {
        GameObject food = foods[Random.Range(0, foods.Count)];
        food = Instantiate(food);
        return food;
    }

    
    public GameObject CreateCheckBox()
    {
        GameObject checkBox = checkBoxs[Random.Range(0, checkBoxs.Count)];
        checkBox = Instantiate(checkBox);
        return checkBox;
    }
}
