using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    Points pointsScript;

    public GameObject[] foodPrefabs;
    public ArrayList foodList;
    Transform foodSpawner;
    FoodItems currentSelectFood;
    List<FoodItems> matchFoods;

    float mouseMoveX;
    float mouseMoveY;

    private void Awake()
    {
        foodSpawner = transform;
        EventControl.eventControl.SignIn(EventDef.foodSelected, OnFoodSelected);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnFoodArrayList();

        // After the frist spawn of food, check if there is any match
        StartCoroutine(AutoMatch());
    }

    private void Update()
    {
        // If no food got clicked then dont run
        if (currentSelectFood == null)
            return;
        // If we are clicking but not selected any food then dont run
        if(Input.GetMouseButtonUp(0))
        {
            currentSelectFood = null;
            return;
        }

        //Input.touchCount == 1 && Input.touches[0].phase == TouchPhase.Moved
        // Give the mouse a moveing dir
        if (Input.GetMouseButton(0))
        {
            mouseMoveX = Input.GetAxis("Mouse X");
            mouseMoveY = Input.GetAxis("Mouse Y");
        }

        // If we move the mouse not far then dont run
        if(Mathf.Abs(mouseMoveX) < .3f && Mathf.Abs(mouseMoveY) < .3f)
        {
            return;
        }

        OnFoodMove();

        // Reset
        mouseMoveX = 0;
        mouseMoveY = 0;
    }

    void SpawnFoodArrayList()
    {
        // Add the food on the plate under the foodspawner gameobject var row and colum index
        foodList = new ArrayList();
        for (int rowIndex = 0; rowIndex < Def.rowCount; rowIndex++)
        {
            ArrayList foodColumList = new ArrayList();
            for (int columIndex = 0; columIndex < Def.columCount; columIndex++)
            {
                FoodItems item = AddRandomFoodItem(rowIndex, columIndex);
                foodColumList.Add(item);
            }
            foodList.Add(foodColumList);
        }
    }

    FoodItems AddRandomFoodItem(int _rowIndex, int _columIndex)
    {
        // Spawn a gameobject under the foodSpawner
        int foodType = Random.Range(0, foodPrefabs.Length);
        GameObject item = new GameObject("Item");
        item.transform.SetParent(foodSpawner, false);

        // Give the new spawned gameobject a boxcollider2d and the fooditems.cs we made
        item.AddComponent<BoxCollider2D>().size = Vector2.one * Def.cellSize;
        FoodItems fooditems = item.AddComponent<FoodItems>();

        // Give the new spawned a new position and image var its row and colum and prefab
        fooditems.UpdatePosition(_rowIndex, _columIndex);
        fooditems.CreateFood(foodType, foodPrefabs[foodType]);
        return fooditems;
    }

    void OnFoodSelected(params object[] args)
    {
        // Get the food that we clicked
        currentSelectFood = args[0] as FoodItems;
    }

    private void OnDestroy()
    {
        // Exit the event when we are not using it
        EventControl.eventControl.SignOut(EventDef.foodSelected, OnFoodSelected);
    }

    FoodItems GetFoodItems(int rowIndex, int columIndex)
    {
        // Check the food is in the right amout of food and put it in the foodlist we have
        if(rowIndex < 0 || rowIndex >= foodList.Count)
        {
            return null;
        }
        ArrayList temp = foodList[rowIndex] as ArrayList;
        if(columIndex < 0 || columIndex >= temp.Count)
        {
            return null;
        }
        return temp[columIndex] as FoodItems;
    }

    void SetFoodItem(int rowIndex, int columIndex, FoodItems item)
    {
        // Return the food value we have when we want to exchange
        ArrayList temp = foodList[rowIndex] as ArrayList;
        temp[columIndex] = item;
    }

    void OnFoodMove()
    {
        // If we are move the food to the left or right
        if (Mathf.Abs(mouseMoveX) > Mathf.Abs(mouseMoveY))
        {
            // Get the food we are moving and see witch way
            FoodItems targetItem = GetFoodItems(currentSelectFood.rowIndex, currentSelectFood.columIndex + (mouseMoveX > 0 ? 1 : -1));

            // If there is a item we clicked then exchange it
            if(targetItem != null)
            {
                StartCoroutine(ExchangeAndMatch(currentSelectFood, targetItem));
            }
            else
            {
                // If no then reset everything
                currentSelectFood = null;
            }
        }

        // Same but move up and down
        else if(Mathf.Abs(mouseMoveX) < Mathf.Abs(mouseMoveY))
        {
            FoodItems targetItem = GetFoodItems(currentSelectFood.rowIndex + (mouseMoveY > 0 ? 1 : -1), currentSelectFood.columIndex);
            if(targetItem != null)
            {
                StartCoroutine(ExchangeAndMatch(currentSelectFood, targetItem));
            }
            else
            {
                currentSelectFood = null;
            }
        }
    }

    void Exchange(FoodItems _item1, FoodItems _item2)
    {
        // Get the two food we want to exchange, get there row and colum.
        SetFoodItem(_item1.rowIndex, _item1.columIndex, _item2);
        SetFoodItem(_item2.rowIndex, _item2.columIndex, _item1);

        // Exchange there row and colum index
        int tmp = 0;
        tmp = _item1.rowIndex;
        _item1.rowIndex = _item2.rowIndex;
        _item2.rowIndex = tmp;
        tmp = _item1.columIndex;
        _item1.columIndex = _item2.columIndex;
        _item2.columIndex = tmp;

        // Exchange there position var index
        _item1.UpdatePosition(_item1.rowIndex, _item1.columIndex, true);
        _item2.UpdatePosition(_item2.rowIndex, _item2.columIndex, true);

        // Clear the cuurentSelectFood
        currentSelectFood = null;
    }

    void AddMatchFood(FoodItems _item)
    {
        // Null check
        if(matchFoods == null)
        {
            matchFoods = new List<FoodItems>();
        }

        // Add all the food that match in to a new arraylist
        int index = matchFoods.IndexOf(_item);
        if(index == -1)
        {
            matchFoods.Add(_item);
        }
    }

    bool CheckHorizontalMatch()
    {
        bool isMatch = false;
        // Loop all the food by horizontal and see if they match
        for (int rowIndex = 0; rowIndex < Def.rowCount; rowIndex++)
        {
            for (int columIndex = 0; columIndex < Def.columCount - 2; columIndex++)
            {
                FoodItems item1 = GetFoodItems(rowIndex, columIndex);
                FoodItems item2 = GetFoodItems(rowIndex, columIndex + 1);
                FoodItems item3 = GetFoodItems(rowIndex, columIndex + 2);

                // If the type of food are all the same then its match
                if(item1.foodType == item2.foodType && item2.foodType == item3.foodType)
                {
                    isMatch = true;
                    AddMatchFood(item1);
                    AddMatchFood(item2);
                    AddMatchFood(item3);
                }
            }
        }
        return isMatch;
    }

    bool CheckVerticalMatch()
    {
        bool isMatch = false;
        // Loop all the food by vertical and see if they match
        for (int columIndex = 0; columIndex < Def.columCount; columIndex++)
        {
            for (int rowIndex = 0; rowIndex < Def.rowCount - 2; rowIndex++)
            {
                FoodItems item1 = GetFoodItems(rowIndex, columIndex);
                FoodItems item2 = GetFoodItems(rowIndex +1, columIndex);
                FoodItems item3 = GetFoodItems(rowIndex +2, columIndex);

                // If the type of food are all the same then its match
                if (item1.foodType == item2.foodType && item2.foodType == item3.foodType)
                {
                    isMatch = true;
                    AddMatchFood(item1);
                    AddMatchFood(item2);
                    AddMatchFood(item3);
                }
            }
        }
        return isMatch;
    }

    void RemoveMatchFood()
    {
        // Loop all the food in the matchfood arraylist and destroy it
        for (int i = 0; i < matchFoods.Count; i++)
        {
            FoodItems item = matchFoods[i] as FoodItems;
            item.DestroyFood();
        }
    }

    void DropDownNewFood()
    {
        // Loop all the holes in the game from match food arraylist
        for (int i = 0; i < matchFoods.Count; i++)
        {
            FoodItems food = matchFoods[i] as FoodItems;

            // Drop down the food that theres a hole below it
            for (int j = food.rowIndex + 1; j < Def.rowCount; j++)
            {
                FoodItems dropDownFood = GetFoodItems(j, food.columIndex);
                dropDownFood.rowIndex--;
                SetFoodItem(dropDownFood.rowIndex, dropDownFood.columIndex, dropDownFood);
                dropDownFood.UpdatePosition(dropDownFood.rowIndex, dropDownFood.columIndex, true);
            }
            ReuseRemovedFood(food);
        }
    }

    void ReuseRemovedFood(FoodItems _food)
    {
        // After drop down the foods, there is hole at the top, fill it up with the food we removed and give it a new food type from prefab
        int foodType = Random.Range(0, foodPrefabs.Length);
        _food.rowIndex = (int)Def.rowCount;
        _food.CreateFood(foodType, foodPrefabs[foodType]);

        // Put it at the top frist
        _food.UpdatePosition(_food.rowIndex, _food.columIndex);

        // Drop it down slowly
        _food.rowIndex--;
        SetFoodItem(_food.rowIndex, _food.columIndex, _food);
        _food.UpdatePosition(_food.rowIndex, _food.columIndex, true);
    }

    IEnumerator ExchangeAndMatch(FoodItems _item1, FoodItems _item2)
    {
        // Run the exchange function
        Exchange(_item1, _item2);

        // Wait till it move to the right position and run 
        yield return new WaitForSeconds(.3f);

        if(CheckHorizontalMatch() || CheckVerticalMatch())
        {
            // Remove the food that match and drop down new food
            RemoveMatchFood();
            yield return new WaitForSeconds(.6f);
            DropDownNewFood();

            // Reset the match food arraylist after remove
            matchFoods = new List<FoodItems>();

            // Check the new spawn food is match
            yield return new WaitForSeconds(.6f);
            StartCoroutine(AutoMatch());
        }
        else
        {
            // If it didn't match, then move the 2 food back to its position
            Exchange(_item1, _item2);
        }
    }

    IEnumerator AutoMatch()
    {
        // Always check is there any match runtime
        if(CheckHorizontalMatch() || CheckVerticalMatch())
        {
            // Remove the match food and wait 0.2s then drop down new food
            RemoveMatchFood();
            yield return new WaitForSeconds(.2f);
            DropDownNewFood();


            // Reset the matchfood arraylist
            matchFoods = new List<FoodItems>();

            // Run this function every .8s
            yield return new WaitForSeconds(.6f);
            StartCoroutine(AutoMatch());
        }
    }
}
