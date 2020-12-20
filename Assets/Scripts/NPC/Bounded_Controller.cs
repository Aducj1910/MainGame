using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounded_Controller : MonoBehaviour, Interactable
{
    [HideInInspector] public GameObject boundedNPC;
    public GameObject fightBar;
    public GameObject indicator;

    public string[] dialogueArray;
    public bool fightingNPC;
    private string barColor;

    private bool dialogueEnded;
    private bool interacting;
    private int fightLoopCounter;
    private bool fightStatusActive;

    private GameObject diagManager;
    private GameObject fightSetup;
    private GameObject inventoryManager;
    private GameObject healthManager;
    private GameObject opponentHealthBar;

    private Weapon activeWeapon;

    public int opponentDamage;
    public int opponentHP;

    void Awake()
    {
        interacting = false;
        fightLoopCounter = 0;

        //Setting the gameobjects
        boundedNPC = GameObject.Find("NPC");
        diagManager = GameObject.Find("DialogueManager");
        fightSetup = GameObject.Find("FightSetup");
        inventoryManager = GameObject.Find("InventoryManager");
        healthManager = GameObject.Find("HealthManager");
        opponentHealthBar = GameObject.Find("OpponentHealthBar");
        fightStatusActive = false;

        opponentHealthBar.GetComponent<HealthBar>().HealthBarSetup(opponentHP);
    }

    void Update()
    {
        if (interacting && fightingNPC)
        {

            dialogueEnded =  diagManager.GetComponent<DialogueManager>().dialogueEndedReturn();
            if (dialogueEnded)
            {
                fightBar.SetActive(true);

                fightStatusActive = true;

                //if(fightLoopCounter < 1) // change the 1 to a variable to change number of times
                //{
                //    fight();
                //    fightLoopCounter++;
                //}
            }
        }
    }

    public void Interact()
    {
        interacting = true;
        diagManager.GetComponent<DialogueManager>().setText(dialogueArray);
        boundedNPC.GetComponent<BoundedNPC>().setIsInteracting();
    }

    public void checkIfFighting()
    {
        barColor = indicator.GetComponent<FightBarController>().getBarColor();
        if (fightStatusActive && opponentHP > 0)
        {
            fightSetup.GetComponent<FightSetup>().setFightEndedStatus(false);
            fight();
        }
    }

    private void fight()
    {

        Weapon w = new Weapon();
        Weapon activeWeapon = inventoryManager.GetComponent<InventoryManager>().getCurrentWeapon();

        if (activeWeapon == w)
        {
            return;
        }
        else //Range (1,4) - red; (7, 12) - yellow; (19, 24) - green;
        {
            if(barColor == "red")
            {
                var mul = Random.Range(1, 4);
                opponentHP = opponentHP - (activeWeapon.damage * mul);
            }
            else if(barColor == "yellow")
            {
                var mul = Random.Range(7, 12);
                opponentHP = opponentHP - (activeWeapon.damage * mul);
            }
            else if(barColor == "green")
            {
                var mul = Random.Range(19, 24);
                opponentHP = opponentHP - (activeWeapon.damage * mul);
            }
            StartCoroutine(handleOpponentAttack());
        }
    }

    IEnumerator handleOpponentAttack()
    {
        var changeInHP = Random.Range(1, 4);
        var damageDealt = changeInHP * opponentDamage;

        healthManager.GetComponent<HealthManager>().updateHealth(-1 * damageDealt);

        opponentHealthBar.GetComponent<HealthBar>().SetHealth(opponentHP);

        if(opponentHP < 0)
        {
            fightSetup.GetComponent<FightSetup>().setFightEndedStatus(true);
        }
        else
        {
            yield return new WaitForSeconds(3);
            indicator.GetComponent<FightBarController>().setIsMoving(true);
        }
    }
}