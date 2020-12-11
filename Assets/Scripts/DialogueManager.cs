using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public GameObject dialogueBox;

    void Start()
    {
        dialogueBox.SetActive(true);
    }

    public void setText(string[] messageArray)
    {
        foreach(var message in messageArray)
        {
            dialogueText.text = message;

            bool isDisplaying = true;
            while (isDisplaying)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    isDisplaying = false;
                }
            }
        }

    }
}
