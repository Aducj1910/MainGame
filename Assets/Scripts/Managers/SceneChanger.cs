using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void loadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }

    public void unloadMainMenuScene()
    {
        SceneManager.UnloadSceneAsync("MainMenu");
    }
}
