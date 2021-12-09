using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour  
{
    public GameObject foodList;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonPressed()
    {
        string currentCategoryName = CategoriesListManagement.GetCurrentCategoryName();
        SceneManager.LoadScene(currentCategoryName + "Scene");
    }


}
