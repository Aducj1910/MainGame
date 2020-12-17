using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounded_Controller : MonoBehaviour, Interactable
{
    [HideInInspector] public GameObject boundedNPC;
    public GameObject fightBar;

    public string[] dialogueArray;
    public bool fightingNPC;

    private bool dialogueEnded;
    private bool interacting;

    private GameObject diagManager;
    private GameObject fightSetup;

    public int opponentDamage;
    public int opponentHP;

    void Awake()
    {
        boundedNPC = GameObject.Find("NPC");
        interacting = false;
        diagManager = GameObject.Find("DialogueManager");
        fightSetup = GameObject.Find("FightSetup");
    }
    
    void Update()
    {
        if (interacting && fightingNPC)
        {

            dialogueEnded =  diagManager.GetComponent<DialogueManager>().dialogueEndedReturn();
            if (dialogueEnded)
            {
                fightSetup.GetComponent<FightSetup>().setFightEndedStatus(false);
                fightBar.SetActive(true);
            }
        }
    }

    public void Interact()
    {
        interacting = true;
        diagManager.GetComponent<DialogueManager>().setText(dialogueArray);
        boundedNPC.GetComponent<BoundedNPC>().setIsInteracting();
    }
}
