using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToCategoryListScene()
    {
        SceneManager.LoadScene("CategoryListScene");
    }

    public void ChangeToDishesListScene()
    {
        SceneManager.LoadScene("DishesListScene");
    }

    public void ChangeToStartingScene()
    {
        SceneManager.LoadScene("Starting Scene");
    }

    public void ChangeToOrderScene()
    {
        SceneManager.LoadScene("OrderScene");
    }
}
