using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour, Interactable
{
    public GameObject dialogueManager;
    public string[] dialogueArray;
    public bool fightingNPC;

    public float opponentDamage;

    public void Interact()
    {
        dialogueManager.GetComponent<DialogueManager>().setText(dialogueArray);
    }
}
