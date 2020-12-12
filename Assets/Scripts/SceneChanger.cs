using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{

    public void loadGameScreen()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void loadMainMenuScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadMainMenu_CraftingScreen()
    {
        SceneManager.LoadScene("MainMenu_Crafting");
    }
}
