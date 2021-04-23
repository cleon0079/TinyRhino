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
        exchange = GameObject.Find("Exchange").GetComponent<ChangeFood>();
        food = GameObject.Find("CreatBox").GetComponent<CreatePlate>();
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
            float food_x = exchange.GetComponent<ChangeFood>().exchange[0].position.x;
            float food_y = exchange.GetComponent<ChangeFood>().exchange[0].position.y;
            float food1_x = exchange.GetComponent<ChangeFood>().exchange[1].position.x;
            float food1_y = exchange.GetComponent<ChangeFood>().exchange[1].position.y;

            if(food_x < 0 || food_y < 0 || food1_x < 0 || food1_y < 0)
            {
                food_x = -food_x;
                food1_x = -food1_x;
                food_y = -food_y;
                food1_y = -food1_y;
            }

            float x = food1_x - food_x;
            float y = food1_y - food_y;

            if(x < 0 || y < 0)
            {
                x = -x;
                y = -y;
            }

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
