using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plateObj;

    // Start is called before the first frame update
    void Start()
    {
        // Place the plate one by one by row and colum index
        for (int rowIndex = 0; rowIndex < Def.rowCount; rowIndex++)
        {
            for (int columIndex = 0; columIndex < Def.columCount; columIndex++)
            {
                GameObject obj = Instantiate(plateObj);
                // Keep all the plate that cloned under the PlateSpawner
                obj.transform.SetParent(plateObj.transform.parent, false);
                obj.transform.localPosition = new Vector3((columIndex - Def.columCount / 2f) * Def.cellSize + Def.cellSize / 2, (rowIndex - Def.rowCount / 2) * Def.cellSize + Def.cellSize / 2);
            }
        }
        plateObj.SetActive(false);
    }
}
