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
        StartCoroutine(displayText(messageArray));

    }

    private IEnumerator displayText(string[] messages)
    {
        foreach(var message in messages)
        {
            dialogueText.text = message;
            yield return waitForKeyPress(KeyCode.Return);
        }
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
