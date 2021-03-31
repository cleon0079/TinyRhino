using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFood : MonoBehaviour
{
    public struct box
    {
        public GameObject pointobject;

        public int x;
        public int y;
    }

    public box[,] m_box;

    [SerializeField] int m_x = 9;
    [SerializeField] int m_y = 9;

    public GameObject spawnPlace;

    public List<GameObject> checkBoxs = new List<GameObject>();
    public List<GameObject> boxGameobjects = new List<GameObject>();
    public List<GameObject> foods = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        int count1 = 0;
        int count2 = 0;
        GameObject thing;
        GameObject thing1;
        GameObject thing2;
        do
        {
            thing = Resources.Load<GameObject>("Prefab/Box/Box_" + count);
            if(thing  != null)
            {
                boxGameobjects.Add(thing);
            }
            count++;
        } while (thing != null);

        do
        {
            thing1 = Resources.Load<GameObject>("Prefab/Foods/" + count1);
            if(thing1 != null)
            {
                foods.Add(thing1);
            }
            count1++;
        } while (thing1 != null);

        do
        {
            thing2 = Resources.Load<GameObject>("Prefab/Box/Check_" + count2);
            if(thing2 != null)
            {
                checkBoxs.Add(thing2);
            }
            count2++;
        } while (thing2 != null);


        //foods = new List<GameObject>(Resources.LoadAll<GameObject>("Prefab/Box"));
        m_box = new box[m_x, m_y];
        for (int j = 0; j < m_y; j++)
        {
            for (int i = 0; i < m_x; i++)
            {
                m_box[i, j].pointobject = boxGameobjects[Random.Range(0, boxGameobjects.Count)];
                GameObject box = Instantiate(m_box[i, j].pointobject, spawnPlace.transform);
                BoxCollider2D collider = box.GetComponentInChildren<BoxCollider2D>();

                //float x = previousbox.GetComponent<Renderer>().bounds.max.x + box.GetComponent<Renderer>().bounds.extents.x;
                float xOffset = collider.size.x * box.transform.localScale.x;
                float yOffset = collider.size.y * box.transform.localScale.y;

                box.transform.localPosition = new Vector3(i * xOffset, j * yOffset);

                m_box[i, j].x = i;
                m_box[i, j].y = j;
            }
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
