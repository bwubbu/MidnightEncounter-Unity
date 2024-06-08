using System.Collections;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public float threshold;
    public GameObject respawnPoint;
    public GameObject player;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                Debug.LogError("Player not found! Please assign the player in the inspector or make sure it has the 'Player' tag.");
            }
        }
    }

    void FixedUpdate()
    {
        if (player != null && player.transform.position.y < threshold)
        {
            respawn();
        }
    }

    public void respawn()
    {
        if (respawnPoint != null && player != null)
        {
            Debug.Log($"Respawning player to respawn point. Player's current position: {player.transform.position}, Respawn point position: {respawnPoint.transform.position}");
            StartCoroutine(RespawnCoroutine());
        }
        else
        {
            if (respawnPoint == null)
            {
                Debug.LogError("Respawn point is not assigned in GameRespawn script.");
            }
            if (player == null)
            {
                Debug.LogError("Player object is null in respawn method.");
            }
        }
    }

    private IEnumerator RespawnCoroutine()
    {
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();

        if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = true;
        }

        player.transform.position = respawnPoint.transform.position;

        if (playerRigidbody != null)
        {
            yield return new WaitForEndOfFrame(); // Wait for a frame to ensure the position is applied
            playerRigidbody.isKinematic = false;
            playerRigidbody.velocity = Vector3.zero; // Reset velocity to prevent unexpected movement
        }

        Debug.Log($"Player's new position: {player.transform.position}");
    }
}
