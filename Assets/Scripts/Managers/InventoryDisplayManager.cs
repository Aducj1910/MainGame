using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplayManager : MonoBehaviour //for ui inventory behaviour
{
    [HideInInspector] public GameObject UI_Inv;
    [HideInInspector] public bool currentSetActiveState;


    void Start()
    {
        UI_Inv = GameObject.Find("UI_Inventory");
        currentSetActiveState = false;
    }

    void Update()
    { 
        UI_Inv.SetActive(currentSetActiveState);


        if (Input.GetKeyDown(KeyCode.C))
        {
            UI_Inv.GetComponent<UI_Inventory>().refreshInventorySlots();
            currentSetActiveState = !currentSetActiveState;
        }
    }
}
