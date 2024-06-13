using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

public class MissionManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public float fadeDuration = 3.0f; // Duration of fade-in and fade-out animations
    public float displayDuration = 3.0f; // Duration to display the text

    private Queue<string> dialogueLines = new Queue<string>(); // Using Queue to store dialogue lines

    void Start()
    {
        // Add your dialogue lines to the queue
        dialogueLines.Enqueue("Take the flashlight in the guard room.");
        dialogueLines.Enqueue("Go to your class to take your backpack.");
        dialogueLines.Enqueue("Find the key.");
        dialogueLines.Enqueue("Open the door");
        dialogueLines.Enqueue("Get out from the faculty and go home.");
    }

    public void StartDialogue()
    {
        // Display the dialogue panel only if there are dialogue lines available
        if (dialogueLines.Count > 0)
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(DisplayDialogue(dialogueLines.Dequeue()));
        }
        else
        {
            Debug.LogWarning("No dialogue lines available to display.");
        }
    }


    IEnumerator DisplayDialogue(String Dialogue)
    {
        dialogueText.text = Dialogue;

        // Fade in
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, 1f);

        // Display for a set duration
        yield return new WaitForSeconds(displayDuration);

        // Fade out
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, 0f);

        // Clear the text
        dialogueText.text = "";

        // Hide the dialogue panel after all lines are displayed
        dialoguePanel.SetActive(false);
    }

    public void HideDialogue()
    {
        StopAllCoroutines(); // Stop the coroutine if it's still running
        dialoguePanel.SetActive(false);
    }
}
