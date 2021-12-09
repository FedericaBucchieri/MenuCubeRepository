using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderManager : MonoBehaviour
{
    public GameObject placeholderCube;
    public GameObject menuCube;
    public GameObject foodList;
    public GameObject AllMenuGameObject;
    public double threeshold = 0.2;
    public bool find = false;
    public int ID = 0;
    public int childrenIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

        if (ID == 1 && MyStorage.firstOrder != null)
        {
            GameObject firstOrder = AllMenuGameObject.transform.Find(MyStorage.firstOrder).gameObject;
            firstOrder.SetActive(true);
            firstOrder.transform.parent = placeholderCube.transform;
            firstOrder.transform.position = placeholderCube.transform.position;
            firstOrder.transform.rotation = placeholderCube.transform.rotation;
        }
        else if(ID == 2 && MyStorage.secondOrder != null)
        {
            GameObject secondOrder = AllMenuGameObject.transform.Find(MyStorage.secondOrder).gameObject;
            secondOrder.SetActive(true);
            secondOrder.transform.parent = placeholderCube.transform;
            secondOrder.transform.position = placeholderCube.transform.position;
            secondOrder.transform.rotation = placeholderCube.transform.rotation;

        }
        else if (ID == 3 && MyStorage.thirdOrder != null)
        {
            GameObject thirdOrder = AllMenuGameObject.transform.Find(MyStorage.thirdOrder).gameObject;
            thirdOrder.SetActive(true);
            thirdOrder.transform.parent = placeholderCube.transform;
            thirdOrder.transform.position = placeholderCube.transform.position;
            thirdOrder.transform.rotation = placeholderCube.transform.rotation;
        }
        else if (ID == 4 && MyStorage.forthOrder != null)
        {
            GameObject forthOrder = AllMenuGameObject.transform.Find(MyStorage.forthOrder).gameObject;
            forthOrder.SetActive(true);
            forthOrder.transform.parent = placeholderCube.transform;
            forthOrder.transform.position = placeholderCube.transform.position;
            forthOrder.transform.rotation = placeholderCube.transform.rotation;
        }
        else if (ID == 5 && MyStorage.fifthOrder != null)
        {
            GameObject fifthOrder = AllMenuGameObject.transform.Find(MyStorage.fifthOrder).gameObject;
            fifthOrder.SetActive(true);
            fifthOrder.transform.parent = placeholderCube.transform;
            fifthOrder.transform.position = placeholderCube.transform.position;
            fifthOrder.transform.rotation = placeholderCube.transform.rotation;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (menuCube != null) {
            if (placeholderCube.activeSelf && menuCube.activeSelf)
            {

                float distance = Vector3.Distance(placeholderCube.transform.position, menuCube.transform.position);

                if (distance < threeshold && !find)
                {
                    if (placeholderCube.transform.childCount > childrenIndex)
                    {
                        // delete the previous child
                        placeholderCube.transform.GetChild(childrenIndex).gameObject.SetActive(false);
                        childrenIndex++;
                    }
                    else {
                        // retrieving the current food displayed
                        GameObject currentFood = FoodListManagement.GetCurrentFood();
                        string currentFoodName = FoodListManagement.GetCurrentFoodName();
                        GameObject duplicateFood = Instantiate(currentFood);

                        // add new child
                        duplicateFood.transform.parent = placeholderCube.transform;
                        duplicateFood.transform.position = placeholderCube.transform.position;
                        duplicateFood.transform.rotation = placeholderCube.transform.rotation;
                        SaveToStorage(currentFood, currentFoodName);
                        find = true;

                        StartCoroutine(StartTimer());
                    }
                }
            }
        }
    }


    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(3);
        find = false;
    }


    private void SaveToStorage(GameObject toBeSaved, string currentFoodName)
    {
        if (ID == 1)
        {
            MyStorage.firstOrder = toBeSaved.name;
            MyStorage.firstOrderName = currentFoodName;
        }
        else if (ID == 2)
        {
            MyStorage.secondOrder = toBeSaved.name;
            MyStorage.secondOrderName = currentFoodName;
        }
        else if (ID == 3)
        {
            MyStorage.thirdOrder = toBeSaved.name;
            MyStorage.thirdOrderName = currentFoodName;
        }
        else if (ID == 4)
        {
            MyStorage.forthOrder = toBeSaved.name;
            MyStorage.forthOrderName = currentFoodName;
        }
        else if (ID == 5)
        {
            MyStorage.fifthOrder = toBeSaved.name;
            MyStorage.fifthOrderName = currentFoodName;
        }
    }

}
