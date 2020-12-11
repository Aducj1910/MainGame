using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenu : MonoBehaviour
{
    private bool isCrafting;
    public GameObject craftingCanvas;
    // Start is called before the first frame update
    void Start()
    {
        isCrafting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCrafting)
        {
            craftingCanvas.SetActive(true);
        }
        else
        {
            craftingCanvas.SetActive(false);
        }

        //update isCrafting
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrafting = !isCrafting;
        }
    }
}
