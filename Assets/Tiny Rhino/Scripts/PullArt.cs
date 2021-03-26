using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullArt : MonoBehaviour
{
    public List<GameObject> objectListThingYea = new List<GameObject>();
    public int maxIndex;
    public string placeHolderString;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxIndex; i++)
        {
            objectListThingYea.Add(Resources.Load("Candy/Thing_"+i)as GameObject);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("CLICK!!!!!!");
            Ray interact;
            interact = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(interact,out hitInfo))
            {
                if(hitInfo.collider.CompareTag("ClickyThing"))
                {
                    Debug.Log("I'm the clicky thing WOOOOOOOOOOOOOOOOOO!");
                    if (placeHolderString != "")
                    {
                        if (hitInfo.collider.gameObject.name == placeHolderString)
                        {
                            Debug.Log("Compare the pair");
                        }
                    }
                    else
                    {
                        placeHolderString = hitInfo.collider.gameObject.name;
                    }
                    
                }
            }
        }
    }
}
