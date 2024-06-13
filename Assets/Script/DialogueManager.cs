using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    private Queue<string> dialogueLines = new Queue<string>(); // Using Queue to store dialogue lines

    void Start()
    {
        // Add your dialogue lines to the queue
        dialogueLines.Enqueue("Its kinda dark in here, let me take that flashlight from the guard room.");
        dialogueLines.Enqueue("My classroom just now is classroom 1.");
        dialogueLines.Enqueue("Noo.. the door is locked! I need to find the key somewhere.");
        dialogueLines.Enqueue("Got it! Now lets get my backpack.");
        dialogueLines.Enqueue("What was that.. and why I don't see my backpack here! Maybe I just need to go back home..");
    }


    public bool  StartDialogue()
    {
        // Display the dialogue panel
        dialoguePanel.SetActive(true);

        // Start the coroutine to gradually reveal the text
        StartCoroutine(RevealText(dialogueLines.Dequeue()));
        return true;
    }

    IEnumerator RevealText(string text)
    {
        dialogueText.text = ""; // Clear the text before revealing

        // Iterate through each character in the text
        foreach (char c in text)
        {
            dialogueText.text += c; // Add the character to the text
            yield return new WaitForSeconds(0.05f); // Wait for the specified time before revealing the next character
        }
    }

    public void NextLine()
    {
        // Check if there are more lines in the queue
        if (dialogueLines.Count > 0)
        {
            // Start the coroutine to reveal the next line of text
            StartCoroutine(RevealText(dialogueLines.Dequeue()));
        }
        else
        {
            // Hide the dialogue panel
            dialoguePanel.SetActive(false);
            // Here you can add code to start the game or do any other actions
        }
    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }


}
