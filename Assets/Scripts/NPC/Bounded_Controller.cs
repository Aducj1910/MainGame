using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounded_Controller : MonoBehaviour, Interactable
{
    public GameObject dialogueManager;
    [HideInInspector] public GameObject boundedNPC;

    public string[] dialogueArray;
    public bool fightingNPC;

    public float opponentDamage;

    void Awake()
    {
        boundedNPC = GameObject.Find("NPC");
    }

    public void Interact()
    {
        dialogueManager.GetComponent<DialogueManager>().setText(dialogueArray);

        boundedNPC.GetComponent<BoundedNPC>().setIsInteracting();
    }
}
