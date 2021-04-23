using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBox : MonoBehaviour
{
    CreateFood food;
    Transform checkBox;

    // Start is called before the first frame update
    void Start()
    {
        food = GameObject.Find("CreatBox").GetComponent<CreateFood>();
        if (transform.childCount == 0)
        {
            GameObject sonFoods = food.CreateCheckBox();
            sonFoods.transform.parent = transform;
            sonFoods.transform.position = transform.position;
        }
        checkBox = this.gameObject.transform.GetChild(0);
    }

    private void OnMouseUpAsButton()
    {
        if (checkBox.GetComponent<SpriteRenderer>().sortingLayerName != "Show")
            checkBox.GetComponent<SpriteRenderer>().sortingLayerName = "Show";
        else
            checkBox.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
    }
}
