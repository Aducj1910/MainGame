using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public GameObject dialogueBox;
    public bool dialogueEnded;

    void Start()
    {
        dialogueBox.SetActive(false);
    }

    public void setText(string[] messageArray)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(displayText(messageArray));

    }

    public bool dialogueEndedReturn()
    {
        return dialogueEnded;
    }

    private IEnumerator displayText(string[] messages)
    {
        foreach(var message in messages)
        {
            dialogueEnded = false;

            FindObjectOfType<AudioManager>().Play("dialogueAppearSound");

            dialogueText.text = message;
            yield return waitForKeyPress(KeyCode.Return);
        }

        dialogueEnded = true;
        dialogueBox.SetActive(false);
    }

    private IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            if (Input.GetKeyDown(key))
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
    }
}
