using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounded_Controller : MonoBehaviour, Interactable
{
    public GameObject dialogueManager;
    [HideInInspector] public GameObject boundedNPC;

    void Awake()
    {
        boundedNPC = GameObject.Find("NPC");
    }

    public void Interact()
    {
        dialogueManager.GetComponent<DialogueManager>().setText(new string[] { "Hello  there...",
            "I  see  you're  not  from  around  here.",
            "Perhaps  you  could  use  a  little  help  crossing  that  broken  bridge  over  there" });

        boundedNPC.GetComponent<BoundedNPC>().setIsInteracting();
    }
}
