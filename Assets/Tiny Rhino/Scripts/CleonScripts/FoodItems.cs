using UnityEngine;

public class FoodItems : MonoBehaviour
{
    public int rowIndex;
    public int columIndex;
    public int foodType;
    public GameObject foodSpriteObj;

    private Transform selfTransform;

    private void Awake()
    {
        selfTransform = transform;
    }

    public void CreateFruitBg(int foodType, GameObject prefab)
    {
        if (foodSpriteObj != null) return;
        this.foodType = foodType;
        foodSpriteObj = Instantiate(prefab);
        foodSpriteObj.transform.localScale = Vector3.one * Def.cellSize;
        foodSpriteObj.transform.SetParent(selfTransform, false);
    }

    public void UpdatePosition(int rowIndex, int columIndex)
    {
        this.rowIndex = rowIndex;
        this.columIndex = columIndex;
        Vector3 targetPos = new Vector3((columIndex - Def.columCount / 2f) * Def.cellSize + Def.cellSize / 2f, (rowIndex - Def.rowCount / 2f) * Def.cellSize + Def.cellSize / 2f, 0);
        selfTransform.localPosition = targetPos;
    }
}
