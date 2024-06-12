using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{

    public void Replay()
    {
        SceneManager.LoadScene("SceneRemastered", LoadSceneMode.Single);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("mainmenu", LoadSceneMode.Single);
    }
}
