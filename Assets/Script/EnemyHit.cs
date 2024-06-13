using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHit : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    public GameObject Camera;

    public GameObject killedTransition;

    public AudioClip scream;
    public AudioClip monsterScream;

    public int killedCount = 0;

    public GameObject canvas; // Reference to the canvas GameObject
    public GameObject[] hearts; // Array to hold references to heart GameObjects
    public GameObject gameOver;

    // Flag to track if the player has been teleported
    private bool hasTeleported = false;

    public GameObject audioSourceObject; // Reference to the GameObject that contains the AudioSource

    private AudioSource audioSource; // Reference to AudioSource component

    private void Start()
    {
        // Ensure the AudioSource component is attached to the specified GameObject
        if (audioSourceObject != null)
        {
            audioSource = audioSourceObject.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = audioSourceObject.AddComponent<AudioSource>();
            }
        }
        else
        {
            Debug.LogError("AudioSourceObject is not assigned!");
        }
    }

    // This method is called when another collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player and if the player hasn't already been teleported
        if (other.CompareTag("Player") && !hasTeleported)
        {
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        if (player != null && respawnPoint != null && killedCount < 2)
        {
            player.transform.position = respawnPoint.transform.position;

            StartCoroutine(EnableKilledTransition());

            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            if (playerRigidbody == null)
            {
                // Add a Rigidbody component if not already attached
                playerRigidbody = player.AddComponent<Rigidbody>();
            }
            // Optionally, you can freeze player's rotation and velocity
            playerRigidbody.freezeRotation = true;
            playerRigidbody.velocity = Vector3.zero;

            RemoveRigidbodyFromPlayer();
            // Reset the flag to allow teleportation again
            hasTeleported = false;
            killedCount++;

            // Disable a heart based on killedCount
            if (killedCount <= hearts.Length)
            {
                hearts[killedCount - 1].SetActive(false);
            }

            // Play the scream audio
            StartScream();
        }
        else if (player != null && killedCount == 2)
        {
            gameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void StartScream()
    {
        if (audioSource != null && scream != null)
        {
            audioSource.clip = scream;
            audioSource.Play();
        }
    }

    private IEnumerator EnableKilledTransition()
    {
        killedTransition.SetActive(true);
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        killedTransition.SetActive(false);
    }

    private void RemoveRigidbodyFromPlayer()
    {
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
        if (playerRigidbody != null)
        {
            Destroy(playerRigidbody);
        }
    }
}
