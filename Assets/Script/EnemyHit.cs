using UnityEngine;
using UnityEngine.UI;

public class EnemyHit : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    public GameObject Camera;

    public int killedCount = 0;

    public GameObject canvas; // Reference to the canvas GameObject
    public GameObject[] hearts; // Array to hold references to heart GameObjects

    // Flag to track if the player has been teleported
    private bool hasTeleported = false;

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
        }
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
