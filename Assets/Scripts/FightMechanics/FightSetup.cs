using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSetup : MonoBehaviour
{
    private GameObject indicator;
    private GameObject inventoryManager;

    void Awake()
    {
        indicator = GameObject.Find("Indicator");
        inventoryManager = GameObject.Find("InventoryManager");
    }
    
    void Update()
    {
        Weapon curWeap = inventoryManager.GetComponent<InventoryManager>().getCurrentWeapon();
        if(curWeap != null)
        {
            float rateOfFire = 10f - ((float)curWeap.rateOfFire); //change this line of code when changin the algo for indicator speed
            indicator.GetComponent<FightBarController>().changeBarSpeed(rateOfFire);
        }
    }
}
