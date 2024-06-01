using System.Collections;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public MissionManager missionManager;
    public AudioClip explosionSound; // Assign your explosion sound in the inspector
    private AudioSource audioSource;
    public GameObject flickeringLight;

    public GameObject Statue;

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
        // Ensure the audio clip is assigned
        if (explosionSound == null)
        {
            Debug.LogError("Explosion sound not assigned to LandMine script.");
        }
    }

    // This method is called when another collider enters the trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            Statue.SetActive(true);
            if (flickeringLight != null)
            {
                flickeringLight.SetActive(true); // Activate the GameObject with the flickering light script
            }
            // Play the explosion sound
            if (explosionSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(explosionSound);
                // Delay the destruction by the length of the sound clip
                Destroy(Statue,explosionSound.length);
                Destroy(flickeringLight,explosionSound.length);
                Destroy(gameObject, explosionSound.length);
                StartCoroutine(DelayedExecution());

            }
            else
            {
                // If the explosion sound or audioSource is missing, destroy immediately
                Destroy(gameObject);
            }
        }
    }
    IEnumerator DelayedExecution()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(6f);

        dialogueManager.StartDialogue();

        Destroy(dialogueManager);
        yield return new WaitForSeconds(3f);
        missionManager.StartDialogue();
    }
}
