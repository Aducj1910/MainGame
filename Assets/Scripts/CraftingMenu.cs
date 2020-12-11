using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenu : MonoBehaviour
{
    private bool isCrafting;
    public GameObject craftingMenuCanvas;
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
            craftingMenuCanvas.SetActive(true);
        }
        else
        {
            craftingMenuCanvas.SetActive(false);
        }

        //update isCrafting
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrafting = !isCrafting;
        }
    }
}
