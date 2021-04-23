using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFood : MonoBehaviour
{
    public Transform[] exchange = new Transform[2];
    public int i = 0;

    public void ExchangeFood()
    {
        Transform m = exchange[0].parent;
        exchange[0].parent = exchange[1].parent;
        exchange[1].parent = m;

        exchange[0].position = exchange[0].parent.position;
        exchange[1].position = exchange[1].parent.position;
    }

    public void ExchangeI()
    {
        i++;
        if (i == 2)
            i = 0;
    }

    public void Clear()
    {
        exchange[0].GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        exchange[1].GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        exchange = new Transform[2];
    }
}
