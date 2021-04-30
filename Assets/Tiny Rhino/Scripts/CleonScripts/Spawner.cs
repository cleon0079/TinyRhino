using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject boxObj;

    // Start is called before the first frame update
    void Start()
    {
        for (int rowIndex = 0; rowIndex < Def.rowCount; rowIndex++)
        {
            for (int columIndex = 0; columIndex < Def.columCount; columIndex++)
            {
                GameObject obj = Instantiate(boxObj);
                obj.transform.SetParent(boxObj.transform.parent, false);
                obj.transform.localPosition = new Vector3((columIndex - Def.columCount / 2f) * Def.cellSize + Def.cellSize / 2, (rowIndex - Def.rowCount / 2) * Def.cellSize + Def.cellSize / 2);
            }
        }
        boxObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
