using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(LoadSceneAfterDelay(1));
    }

    IEnumerator LoadSceneAfterDelay(int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("mainmenu", LoadSceneMode.Single);
    }
}