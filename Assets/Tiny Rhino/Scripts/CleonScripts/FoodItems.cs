using UnityEngine;
using DG.Tweening;

public class FoodItems : MonoBehaviour
{
    Points pointsScript;

    public int rowIndex;
    public int columIndex;
    public int foodType;
    public GameObject foodSpriteObj;

    private Transform selfTransform;

    private void Awake()
    {
        selfTransform = transform;
    }

    public void CreateFood(int _foodType, GameObject _prefab)
    {
        // Spawn the food prefab under the foodspawner gameobject and reset its size and transform, and give it a int for the type of food
        if (foodSpriteObj != null) return;
        this.foodType = _foodType;
        foodSpriteObj = Instantiate(_prefab);
        foodSpriteObj.transform.localScale = Vector3.one * Def.cellSize;
        foodSpriteObj.transform.SetParent(selfTransform, false);
    }

    public void UpdatePosition(int _rowIndex, int _columIndex, bool _dotween = false)
    {
        // Locate the row and column index
        this.rowIndex = _rowIndex;
        this.columIndex = _columIndex;

        // Change the position var the row and column index
        Vector3 targetPos = new Vector3((_columIndex - Def.columCount / 2f) * Def.cellSize + Def.cellSize / 2f, (_rowIndex - Def.rowCount / 2f) * Def.cellSize + Def.cellSize / 2f, 0);
        if(_dotween)
        {
            // Give the food a delay time to move to new position
            selfTransform.DOLocalMove(targetPos, .3f);
        }
        else
        {
            selfTransform.localPosition = targetPos;
        }
    }

    private void OnMouseDown()
    {
        // This Food got selected when we clicked and put the food in to the clicked event handle
        EventControl.eventControl.DispatchEvent(EventDef.foodSelected, this);
    }

    public void DestroyFood()
    {      
        // Destroy the food when it match
        Destroy(foodSpriteObj);
        foodSpriteObj = null;

        // adds a point per food destroyed
        Points.points++;
        
    }
}
