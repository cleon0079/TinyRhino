using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfClick : MonoBehaviour
{
    ChangeFood exchange;
    Transform checkBox;
    CreatePlate food;

    private void Start()
    {
        exchange = GameObject.FindObjectOfType<ChangeFood>().GetComponent<ChangeFood>();
        food = GameObject.FindObjectOfType<CreatePlate>().GetComponent<CreatePlate>();
    }

    private void OnMouseUpAsButton()
    {
        checkBox = this.gameObject.transform.GetChild(0);
        int j = exchange.i;

        if (checkBox.GetComponent<SpriteRenderer>().sortingLayerName != "Show")
            checkBox.GetComponent<SpriteRenderer>().sortingLayerName = "Show";
        else
            checkBox.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

        if (j < 2)
            exchange.GetComponent<ChangeFood>().exchange[j] = this.gameObject.transform;

        if(exchange.GetComponent<ChangeFood>().exchange[1] != null)
        {
            float food_x = Mathf.Abs(exchange.GetComponent<ChangeFood>().exchange[0].position.x);
            float food_y = Mathf.Abs(exchange.GetComponent<ChangeFood>().exchange[0].position.y);
            float food1_x = Mathf.Abs(exchange.GetComponent<ChangeFood>().exchange[1].position.x);
            float food1_y = Mathf.Abs(exchange.GetComponent<ChangeFood>().exchange[1].position.y);

            float x = Mathf.Abs(food1_x - food_x);
            float y = Mathf.Abs(food1_y - food_y);

            if(food1_y == food_y && x == food.xOffset)
            {
                exchange.ExchangeFood();
                exchange.Clear();
            }
            else if(food1_x == food_x && y == food.yOffset)
            {
                exchange.ExchangeFood();
                exchange.Clear();
            }
            else
            {
                exchange.Clear();
            }
        }
    }
}
