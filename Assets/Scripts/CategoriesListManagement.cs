using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CategoriesListManagement : MonoBehaviour
{
    public GameObject[] categoriesList;
    public GameObject[] cubeFaces;
    public GameObject currentFace;
    public GameObject categoryPosition;
    public GameObject currentCategory;
    private int currentIndex;
    private bool initialized = false;


    public void ShowFirstCategory()
    {
        Debug.Log("initialized: " + initialized);
        if (!initialized)
        {
            // Deactivating all the food in the list except the first one
            for (int i = 1; i < categoriesList.Length; i++)
            {
                categoriesList[i].SetActive(false);
            }

            // Placing the first list element in the correct position
            categoriesList[0].transform.position = categoryPosition.transform.position;
            currentCategory = categoriesList[0];

            initialized = true;
        }
    }

    public void switchCategory(GameObject cubeFace)
    {
        Debug.Log("Switch category. Cube Face: " + cubeFace.name + " Current Face: " + currentFace.name);
        for (int i = 0; i < categoriesList.Length; i++)
        {
            if (cubeFaces[i] == cubeFace)
            {
                // If I moved to the previous face
                if (i > 0 && currentFace == cubeFaces[i - 1])
                    PreviousCategory();
                // special case: first Face
                else if (i == 0 && currentFace == cubeFaces[cubeFaces.Length - 1])
                    PreviousCategory();
                // If I moved to the next face
                else if (i < cubeFaces.Length - 1 && currentFace == cubeFaces[i + 1])
                    NextCategory();
                // special case: last Face
                else if (i == cubeFaces.Length - 1 && currentFace == cubeFaces[0])
                    NextCategory();

                //Update current Face
                currentFace = cubeFace;

                Debug.Log("current category: " + currentCategory.name);

                break;
            }
                
        }
    }

    public void NextCategory()
    {
        if (currentIndex < categoriesList.Length - 1)
        {
            // deActivate previous food object
            categoriesList[currentIndex].SetActive(false);

            // update the currentIndex
            currentIndex++;

            // activate next one and place it in the right position
            categoriesList[currentIndex].SetActive(true);
            categoriesList[currentIndex].transform.position = categoryPosition.transform.position;
            currentCategory = categoriesList[currentIndex];
        }
        else
        {
            Debug.Log("Last category in list");
        }
    }


    public void PreviousCategory()
    {
        if (currentIndex > 0)
        {
            // deActivate previous food object
            categoriesList[currentIndex].SetActive(false);

            // update the currentIndex
            currentIndex--;

            // activate next one and place it in the right position
            categoriesList[currentIndex].SetActive(true);
            categoriesList[currentIndex].transform.position = categoryPosition.transform.position;
            currentCategory = categoriesList[currentIndex];
        }
        else
        {
            Debug.Log("First category in list");
        }
    }

    public void GoToCategoryScene()
    {
        SceneManager.LoadScene(currentCategory.name + "Scene");
    }
}
