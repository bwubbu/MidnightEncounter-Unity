using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(LoadSceneAfterDelay(1));
    }

    IEnumerator LoadSceneAfterDelay(int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("SceneRemastered", LoadSceneMode.Single);
    }
}