using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSetup : MonoBehaviour
{
    private GameObject indicator;
    private GameObject inventoryManager;
    private GameObject fightBar;

    [HideInInspector] public static bool fightEnded;

    void Awake()
    {
        indicator = GameObject.Find("Indicator");
        inventoryManager = GameObject.Find("InventoryManager");
        fightBar = GameObject.Find("FightBar");
        fightEnded = true;

        fightBar.SetActive(false);
    }
    
    void Update()
    {
        Weapon curWeap = inventoryManager.GetComponent<InventoryManager>().getCurrentWeapon();
        if(curWeap != null)
        {
            float rateOfFire = 10f - ((float)curWeap.handling); //change this line of code when changin the algo for indicator speed
            indicator.GetComponent<FightBarController>().changeBarSpeed(rateOfFire);
        }
    }

    public void setFightEndedStatus(bool tempFightEnded)
    {
        fightEnded = tempFightEnded;
    }

    public bool getFightEndedStatus()
    {
        return fightEnded;
    }

}
