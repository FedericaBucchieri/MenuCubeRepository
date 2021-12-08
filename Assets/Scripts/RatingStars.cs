using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RatingStars : MonoBehaviour
{
    public GameObject[] starsImages;
    public GameObject ratingCube;
    public GameObject menuCube;
    public double[] threesholds = { 0.1, 0.2, 0.3, 0.4, 0.5 };
    public GameObject foodList;

    // Start is called before the first frame update
    void Start()
    {
        // Deactivating all the stars ate the beginning
        for (int i = 0; i < starsImages.Length; i++)
        {
            starsImages[i].SetActive(false);
        }

    }



    // Update is called once per frame
    void Update()
    {

        if (ratingCube.activeSelf && menuCube.activeSelf)
        {

            float distance = Vector3.Distance(ratingCube.transform.position, menuCube.transform.position);

            for (int i = 0; i < threesholds.Length; i++)
            {
                if (distance > threesholds[i])
                    starsImages[i].SetActive(false);
                else
                    starsImages[i].SetActive(true);
            }
        }

    }


    public void Reset()
    {
        // Deactivating all the stars at the beginning
        for (int i = 0; i < starsImages.Length; i++)
        {
            starsImages[i].SetActive(false);
        }
    }

    public void ButtonPressed()
    {
        int rating = 0;

        for (int i = 0; i < starsImages.Length; i++)
        {
            if (starsImages[i].activeSelf)
                rating++;
        }

        foodList.GetComponent<FoodListManagement>().UpdateRating(rating);

        // reset the previous UI
        Reset();
    }

}
