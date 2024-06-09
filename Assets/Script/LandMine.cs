using System.Collections;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    public GameManager gameManager;
    public AudioClip explosionSound; // Assign your explosion sound in the inspector
    private AudioSource audioSource;
    public GameObject flickeringLight;
    public GameObject monster;
    private bool dialogueVisible = true;

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
            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }
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
                Destroy(Statue,2f);
                Destroy(Statue,2f);
                Destroy(flickeringLight,explosionSound.length);
                gameManager.StartDialogueFromOther();
                monster.SetActive(true);

            }
            else
            {
                // If the explosion sound or audioSource is missing, destroy immediately
                Destroy(gameObject);
            }
        }
    }
}
