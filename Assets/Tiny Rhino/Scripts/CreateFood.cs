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


    List<GameObject> foods = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        GameObject thing;
        do
        {
            thing = Resources.Load<GameObject>("Prefab/Box/Thing_" + count);
            if(thing  != null)
            {
                foods.Add(thing);
            }
            count++;
        } while (thing != null);

        //foods = new List<GameObject>(Resources.LoadAll<GameObject>("Prefab/Box"));
        m_food = new food[m_x, m_y];
        for (int j = 0; j < m_y; j++)
        {
            for (int i = 0; i < m_x; i++)
            {
                m_food[i, j].pointobject = foods[Random.Range(0, foods.Count)];
                GameObject box = Instantiate(m_food[i, j].pointobject);
                BoxCollider2D collider = box.GetComponent<BoxCollider2D>();

                //float x = previousbox.GetComponent<Renderer>().bounds.max.x + box.GetComponent<Renderer>().bounds.extents.x;

                box.transform.localPosition = new Vector2(i * collider.size.x, j * collider.size.y);

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
