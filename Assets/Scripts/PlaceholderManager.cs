using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderManager : MonoBehaviour
{
    public GameObject placeholderCube;
    public GameObject menuCube;
    public GameObject foodList;
    public double threeshold = 0.2;
    public bool find = false;
    public int ID = 0;

    // Start is called before the first frame update
    void Start()
    {

        //Debug.Log(MyStorage.firstOrder.name);

        if (ID == 1 && MyStorage.firstOrder != null)
        {
            GameObject duplicateFood = Instantiate(MyStorage.firstOrder);
            duplicateFood.transform.parent = placeholderCube.transform;
            duplicateFood.transform.position = placeholderCube.transform.position;
            duplicateFood.transform.rotation = placeholderCube.transform.rotation;
        }
        else if(ID == 2 && MyStorage.secondOrder != null)
        {
            GameObject duplicateFood = Instantiate(MyStorage.secondOrder);
            duplicateFood.transform.parent = placeholderCube.transform;
            duplicateFood.transform.position = placeholderCube.transform.position;
            duplicateFood.transform.rotation = placeholderCube.transform.rotation;
        }
        else if (ID == 3 && MyStorage.thirdOrder != null)
        {
            GameObject duplicateFood = Instantiate(MyStorage.thirdOrder);
            duplicateFood.transform.parent = placeholderCube.transform;
            duplicateFood.transform.position = placeholderCube.transform.position;
            duplicateFood.transform.rotation = placeholderCube.transform.rotation;
        }
        else if (ID == 4 && MyStorage.forthOrder != null)
        {
            GameObject duplicateFood = Instantiate(MyStorage.forthOrder);
            duplicateFood.transform.parent = placeholderCube.transform;
            duplicateFood.transform.position = placeholderCube.transform.position;
            duplicateFood.transform.rotation = placeholderCube.transform.rotation;
        }
        else if (ID == 5 && MyStorage.fifthOrder != null)
        {
            GameObject duplicateFood = Instantiate(MyStorage.fifthOrder);
            duplicateFood.transform.parent = placeholderCube.transform;
            duplicateFood.transform.position = placeholderCube.transform.position;
            duplicateFood.transform.rotation = placeholderCube.transform.rotation;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (placeholderCube.activeSelf && menuCube.activeSelf)
        {

            float distance = Vector3.Distance(placeholderCube.transform.position, menuCube.transform.position);

            if(distance < threeshold && !find)
            {
                if (placeholderCube.transform.childCount > 0)
                {
                    // delete the previous child
                    Destroy(placeholderCube.transform.GetChild(0).gameObject);
                }
                else { 
                    // retrieving the current food displayed
                    GameObject currentFood = FoodListManagement.GetCurrentFood();
                    GameObject duplicateFood = Instantiate(currentFood);

                    // add new child
                    duplicateFood.transform.parent = placeholderCube.transform;
                    duplicateFood.transform.position = placeholderCube.transform.position;
                    duplicateFood.transform.rotation = placeholderCube.transform.rotation;
                    SaveToStorage(duplicateFood);
                    find = true;

                    StartCoroutine(StartTimer());
                }
            }
        }
    }


    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(3);
        find = false;
    }


    private void SaveToStorage(GameObject toBeSaved)
    {
        if (ID == 1)
            MyStorage.firstOrder = toBeSaved;
        else if (ID == 2)
            MyStorage.secondOrder = toBeSaved;
        else if (ID == 3)
            MyStorage.thirdOrder = toBeSaved;
        else if (ID == 4)
            MyStorage.forthOrder = toBeSaved;
        else if (ID == 5)
            MyStorage.fifthOrder = toBeSaved;
    }

}
