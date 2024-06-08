using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawnFunction : MonoBehaviour
{
    GameRespawn gameRespawn;
    public void RespawnFunc()
    {
        Debug.Log("Button Clicked");
        gameRespawn.respawn();
    }
}
