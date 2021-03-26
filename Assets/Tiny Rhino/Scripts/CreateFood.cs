using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFood : MonoBehaviour
{

    public struct food
    {
        public GameObject pointobject;

        public int x;
        public int y;
    }

    public food[,] m_food;

    private int m_x = 9;
    private int m_y = 9;

    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < m_y; j++)
        {
            for (int i = 0; i < m_x; i++)
            {
                m_food[i, j].pointobject = Resources.Load("Prefab/Box") as GameObject;
                GameObject box = Instantiate(m_food[i, j].pointobject);

                box.transform.localPosition = new Vector2(i * 10, j * 10);

                m_food[i, j].x = i;
                m_food[i, j].y = j;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
