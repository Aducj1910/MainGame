using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplayManager : MonoBehaviour //for ui inventory behaviour
{
    [HideInInspector] public GameObject UI_Inv;
    private bool currentSetActiveState;
    [HideInInspector] public GameObject UI_Inv2;
    private bool currentSetActiveState2;


    void Start()
    {
        UI_Inv = GameObject.Find("UI_Inventory");
        currentSetActiveState = false;

        UI_Inv2 = GameObject.Find("UI_Inventory2");
        currentSetActiveState2 = false; 
    }

    void Update()
    { 
        UI_Inv.SetActive(currentSetActiveState);
        UI_Inv2.SetActive(currentSetActiveState2);

        if (Input.GetKeyDown(KeyCode.W))
        {
            UI_Inv.GetComponent<UI_Inventory>().refreshInventorySlots();
            currentSetActiveState = !currentSetActiveState;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            UI_Inv2.GetComponent<UI_Inventory2>().refreshInventorySlots();
            currentSetActiveState2 = !currentSetActiveState2;
        }
    }
}
