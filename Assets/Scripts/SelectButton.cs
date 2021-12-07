using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour  
{
    public GameObject virtualButton;
    public GameObject foodList;

    // Start is called before the first frame update
    void Start()
    {
        virtualButton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(onButtonPressed);
        virtualButton.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(onButtonReleased);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonPressed(VirtualButtonBehaviour vb)
    {
        string currentCategoryName = CategoriesListManagement.GetCurrentCategoryName();
        SceneManager.LoadScene(currentCategoryName + "Scene");
    }


    public void onButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Virtual button released");
       
    }
}
