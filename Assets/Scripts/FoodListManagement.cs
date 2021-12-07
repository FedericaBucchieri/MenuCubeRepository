using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodListManagement : MonoBehaviour
{
    public GameObject[] foodList;
    public GameObject[] cubeFaces;
    public GameObject currentFace;
    public GameObject foodPosition;
    public GameObject currentFood;
    public static GameObject currentFoodPointer;
    public int switchMax;
    private int currentIndex;
    private bool initialized = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowFirstFood()
    {
        if (!initialized)
        {
            // Deactivating all the food in the list except the first one
            for (int i = 1; i < foodList.Length; i++)
            {
                foodList[i].SetActive(false);
            }

            // Placing the first list element in the correct position
            foodList[0].transform.position = foodPosition.transform.position;
            currentFood = foodList[0];
            currentFoodPointer = currentFood;
            initialized = true;
        }
    }

    public void switchFood(GameObject cubeFace)
    {

        for (int i = 0; i < switchMax; i++)
        {
            if (cubeFaces[i] == cubeFace)
            {
                // If I moved to the previous face
                if (i > 0 && currentFace == cubeFaces[i - 1])
                    PreviousFood();
                // special case: first Face
                else if (i == 0 && currentFace == cubeFaces[cubeFaces.Length - 1])
                    PreviousFood();
                // If I moved to the next face
                else if (i < cubeFaces.Length - 1 && currentFace == cubeFaces[i + 1])
                    NextFood();
                // special case: last Face
                else if (i == cubeFaces.Length - 1 && currentFace == cubeFaces[0])
                    NextFood();

                //Update current Face
                currentFace = cubeFace;

                Debug.Log("current Food: " + currentFood.name);

                break;
            }

        }
    }

    public void NextFood()
    {
        Debug.Log(" ************************ NEXT");

        if (currentIndex < foodList.Length - 1)
        {
            // deActivate previous food object
            foodList[currentIndex].SetActive(false);

            // update the currentIndex
            currentIndex++;

            // activate next one and place it in the right position
            foodList[currentIndex].SetActive(true);
            foodList[currentIndex].transform.position = foodPosition.transform.position;
            currentFood = foodList[currentIndex];
            currentFoodPointer = currentFood;
        }
        else
        {
            Debug.Log("Last food in list");
        }
    }


    public void PreviousFood()
    {
        Debug.Log(" ************************ PREVIOUS");

        if (currentIndex > 0)
        {
            // deActivate previous food object
            foodList[currentIndex].SetActive(false);

            // update the currentIndex
            currentIndex--;

            // activate next one and place it in the right position
            foodList[currentIndex].SetActive(true);
            foodList[currentIndex].transform.position = foodPosition.transform.position;
            currentFood = foodList[currentIndex];
            currentFoodPointer = currentFood;
        }
        else
        {
            Debug.Log("First food in list");
        }
    }

    public static GameObject GetCurrentFood()
    {
        return currentFoodPointer;
    }

    public void UpdateRating(int rating)
    {
        GameObject canvas = currentFood.transform.Find("Canvas").gameObject;
        GameObject ratingStarsParent = canvas.transform.Find("RatingStarsSaved").gameObject;

        // reset
        for (int i = 0; i < 4; i++)
        {
            ratingStarsParent.transform.GetChild(i).gameObject.SetActive(false);
        }

        // new rating
        for (int i = 0; i < rating; i++)
        {
            ratingStarsParent.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

}

