using System.Collections;
using CameraDoorScript;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public ItemHolder itemHolder;
    public CameraOpenDoor cameraOpenDoor;
    public MissionManager missionManager;
    private bool dialogueVisible = false;
    private bool missionStarted = false; // Flag to track if the mission has already been started

    void Start()
    {
        // Check if cameraOpenDoor is assigned
        if (cameraOpenDoor == null)
        {
            Debug.LogError("cameraOpenDoor is not assigned in the Inspector!");
        }
        
        // Invoke StartDialogue() after a delay of 2 seconds
        Invoke("StartDialogueAfterDelay", 2f);
    }

    void StartDialogueAfterDelay()
    {
        // Call StartDialogue() directly on dialogueManager
        dialogueManager.StartDialogue();
        dialogueVisible = true;
    }

    void Update()
    {
        // Check for mouse click to hide the dialogue
        if (Input.GetMouseButtonDown(0) && dialogueVisible) // 0 represents the left mouse button
        {
            Debug.Log("clicked dialogue");
            dialogueManager.HideDialogue();
            dialogueVisible = false; // Update the flag
            if (!missionStarted) // Check if the mission hasn't been started yet
            {
                missionManager.StartDialogue();
                StartCoroutine(Mission1()); // Start the coroutine to handle the mission
            }

        }
    }

    IEnumerator Mission1()
    {
        Debug.Log("Mission routine started");
        missionStarted = true; // Set the mission flag
        yield return new WaitForSeconds(0.1f); // Wait for a short time before starting the mission

        while (!itemHolder.HasItem("Flashlight")) // Continue looping until the player picks up the flashlight
        {
            yield return null; // Wait for the next frame
        }

        // Once the player picks up the flashlight, start the mission dialogue
        missionManager.StartDialogue();

        yield return new WaitForSeconds(2f); // Delay for 2 seconds

        // After 2 seconds, start the dialogue again
        dialogueManager.StartDialogue();
        dialogueVisible = true;

        // Start the next mission coroutine
        StartCoroutine(Mission2());
    }

    IEnumerator Mission2()
    {
        Debug.Log("Mission 2 routine started");

        if (cameraOpenDoor == null)
        {
            Debug.LogError("cameraOpenDoor is not assigned in the Inspector!");
            yield break; // Exit the coroutine if cameraOpenDoor is null
        }

        while (!cameraOpenDoor.CheckForInteraction()) // Continue looping until the player interacts with the door
        {
            yield return null; // Wait for the next frame
        }

        // After 2 seconds, start the dialogue again
        dialogueManager.StartDialogue();
        dialogueVisible = true;

        yield return new WaitForSeconds(2f); // Delay for 2 seconds
        // Once the player interacts with the locked door, start the mission dialogue
        missionManager.StartDialogue();
        
        StartCoroutine(Mission3());
        
    }

    IEnumerator Mission3()
    {
        Debug.Log("Mission 3 routine started");
        missionStarted = true; // Set the mission flag
        yield return new WaitForSeconds(0.1f); // Wait for a short time before starting the mission

        while (!itemHolder.HasItem("Key")) // Continue looping until the player picks up the flashlight
        {
            yield return null; // Wait for the next frame
        }


        // After 2 seconds, start the dialogue again
        dialogueManager.StartDialogue();
        dialogueVisible = true;

        yield return new WaitForSeconds(2f); // Delay for 2 seconds
        missionManager.StartDialogue(); 
    }

    public void StartDialogueFromOther()
    {
        // Call StartDialogue() directly on dialogueManager
        
        Invoke("StartOtherDialogue", 4f);
    }

    void StartOtherDialogue()
    {
        dialogueManager.StartDialogue();
        dialogueVisible = true;
        Invoke("StartOtherMission", 4f);
    }
    void StartOtherMission()
    {
        missionManager.StartDialogue();
    }
}

